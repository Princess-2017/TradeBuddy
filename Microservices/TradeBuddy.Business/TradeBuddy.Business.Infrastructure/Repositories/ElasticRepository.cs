using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Common.Interfaces;

namespace TradeBuddy.Business.Infrastructure.Repositories
{
    public class ElasticRepository<T> : IElasticRepository<T> where T : class
    {
        private readonly IElasticClient _elasticClient;

        public ElasticRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task IndexAsync(T entity)
        {
            var response = await _elasticClient.IndexDocumentAsync(entity);
            if (!response.IsValid)
            {
                throw new Exception($"Failed to index document: {response.OriginalException?.Message}");
            }
        }

        public async Task<List<T>> SearchAsync(string query, Dictionary<string, object> filters)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .MultiMatch(mm => mm
                                .Fields(f => f.Field("*"))
                                .Query(query)
                            )
                        )
                    )
                )
            );

            if (!searchResponse.IsValid)
            {
                throw new Exception($"Search failed: {searchResponse.OriginalException?.Message}");
            }

            return searchResponse.Documents.ToList();
        }
    }
}
