using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Application.Queries;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.FeatureValues.Queries
{
    public class GetFeatureValueByIdQueryHandler : IRequestHandler<GetFeatureValueByIdQuery, FeatureValueDto>
    {
        private readonly IRepository<FeatureValue, Guid> _featureValueRepository;

        public GetFeatureValueByIdQueryHandler(IRepository<FeatureValue, Guid> featureValueRepository)
        {
            _featureValueRepository = featureValueRepository;
        }

        public async Task<FeatureValueDto> Handle(GetFeatureValueByIdQuery request, CancellationToken cancellationToken)
        {
            var featureValue = await _featureValueRepository.GetByIdAsync(request.FeatureValueId);

            if (featureValue == null)
                return null;

            return new FeatureValueDto
            {
                Id = featureValue.Id,
                FeatureId = featureValue.FeatureId,
                Value = featureValue.Value
            };
        }
    }
}
