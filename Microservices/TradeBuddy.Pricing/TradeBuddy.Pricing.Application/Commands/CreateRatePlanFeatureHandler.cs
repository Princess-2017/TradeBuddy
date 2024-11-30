using MediatR;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreateRatePlanFeatureHandler : IRequestHandler<CreateRatePlanFeatureCommand, int>
    {
        private readonly IRepository<RatePlanFeature, int> _repository;

        public CreateRatePlanFeatureHandler(IRepository<RatePlanFeature, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateRatePlanFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = new RatePlanFeature
            {
                RatePlanId = request.Dto.RatePlanId,
                FeatureName = request.Dto.FeatureName,
                FeatureValue = request.Dto.FeatureValue,
                AdditionalPrice = request.Dto.AdditionalPrice
            };

            await _repository.AddAsync(entity);
            return entity.Id;
        }
    }

}
