using MediatR;
using System.Linq.Expressions;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetAllFeaturesQueryHandler : IRequestHandler<GetAllFeaturesQuery, List<FeatureDto>>
    {
        private readonly IRepository<Feature, Guid> _featureRepository;

        public GetAllFeaturesQueryHandler(IRepository<Feature, Guid> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<List<FeatureDto>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            // جستجو بر اساس BusinessId
            Expression<Func<TradeBuddy.Store.Domain.Entities.Feature, bool>> predicate = r => r.StoreId == request.StoreId;

            var features = await _featureRepository.SearchAsync(predicate);

            return features.Select(f => new FeatureDto
            {
                Id = f.Id,
                Name = f.Name
            }).ToList();
        }
    }
}
