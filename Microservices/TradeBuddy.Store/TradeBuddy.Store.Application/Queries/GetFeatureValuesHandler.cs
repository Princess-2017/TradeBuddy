using MediatR;
using System.Linq.Expressions;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetFeatureValuesHandler : IRequestHandler<GetFeatureValuesQuery, List<FeatureValueDto>>
    {
        private readonly IRepository<FeatureValue, Guid> _featureValueRepository;

        public GetFeatureValuesHandler(IRepository<FeatureValue, Guid> featureValueRepository)
        {
            _featureValueRepository = featureValueRepository;
        }

        public async Task<List<FeatureValueDto>> Handle(GetFeatureValuesQuery request, CancellationToken cancellationToken)
        {

            // جستجو بر اساس BusinessId
            Expression<Func<TradeBuddy.Store.Domain.Entities.FeatureValue, bool>> predicate = r => r.FeatureId == request.FeatureId;

            var featureValues = await _featureValueRepository.SearchAsync(predicate);


            return featureValues.Select(fv => new FeatureValueDto
            {
                Id = fv.Id,
                Value = fv.Value,
                FeatureId = fv.FeatureId
            }).ToList();
        }
    }
}
