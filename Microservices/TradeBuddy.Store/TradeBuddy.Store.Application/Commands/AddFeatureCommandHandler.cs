using MediatR;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddFeatureCommandHandler : IRequestHandler<AddFeatureCommand, Guid>
    {
        private readonly IRepository<Feature, Guid> _featureRepository;
        private readonly IRepository<FeatureDependency, Guid> _dependencyRepository;

        public AddFeatureCommandHandler(IRepository<Feature, Guid> featureRepository, IRepository<FeatureDependency, Guid> dependencyRepository)
        {
            _featureRepository = featureRepository;
            _dependencyRepository = dependencyRepository;
        }

        public async Task<Guid> Handle(AddFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = new Feature
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                StoreId = request.StoreId,
            };

            await _featureRepository.AddAsync(feature);

            foreach (var dependencyId in request.DependencyIds)
            {
                var dependency = new FeatureDependency
                {
                    Id = Guid.NewGuid(),
                    FeatureId = feature.Id,
                    DependentFeatureId = dependencyId
                };

                await _dependencyRepository.AddAsync(dependency);
            }

            return feature.Id;
        }
    }
}
