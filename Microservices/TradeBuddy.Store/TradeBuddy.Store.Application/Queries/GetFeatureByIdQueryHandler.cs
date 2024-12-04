using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, FeatureDto>
    {
        private readonly IRepository<Feature, Guid> _featureRepository;

        public GetFeatureByIdQueryHandler(IRepository<Feature, Guid> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<FeatureDto> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var feature = await _featureRepository.GetByIdAsync(request.FeatureId);

            if (feature == null)
                return null;

            return new FeatureDto
            {
                Id = feature.Id,
                Name = feature.Name,
            };
        }
    }
}
