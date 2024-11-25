using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Service.Elastic
{
    public class SearchBusinessesQueryHandler : IRequestHandler<SearchBusinessesQuery, List<BusinessElasticModel>>
    {
        private readonly IElasticClient _elasticClient;

        public SearchBusinessesQueryHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<List<BusinessElasticModel>> Handle(SearchBusinessesQuery request, CancellationToken cancellationToken)
        {
            var searchDescriptor = new SearchDescriptor<BusinessElasticModel>()
                .Index("business-index")
                .Query(q =>
                    q.Bool(b => b
                        .Must(
                            // اینجا کوئری‌ها مستقیماً تعریف می‌شوند
                            must =>
                            {
                                if (!string.IsNullOrEmpty(request.Keyword))
                                {
                                    return must.MultiMatch(mm => mm
                                        .Fields(f => f
                                            .Field(f => f.Name)
                                            .Field(f => f.Description)
                                            .Field(f => f.Address))
                                        .Query(request.Keyword)
                                        .Fuzziness(Fuzziness.Auto));
                                }

                                //if (!string.IsNullOrEmpty(request.City))
                                //{
                                //    return must.Term(t => t.Field(f => f.City).Value(request.City));
                                //}

                                if (request.IsVerified.HasValue)
                                {
                                    return must.Term(t => t.Field(f => f.IsVerified).Value(request.IsVerified.Value));
                                }

                                return null; // در صورت نبود شرط خاص، کوئری خالی
                            }
                        )
                    )
                );

            var searchResponse = await _elasticClient.SearchAsync<BusinessElasticModel>(searchDescriptor, cancellationToken);

            if (!searchResponse.IsValid)
            {
                throw new Exception($"Search failed: {searchResponse.ServerError?.Error.Reason}");
            }

            return searchResponse.Documents.ToList();
        }
    }
}