using MediatR;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreatePricingPlanCommandHandler : IRequestHandler<CreatePricingPlanCommand, int>
    {
        private readonly IRepository<PricingPlan, int> _repository;

        public CreatePricingPlanCommandHandler(IRepository<PricingPlan, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreatePricingPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = new PricingPlan
            {
                Name = request.Dto.Name,
                Description = request.Dto.Description,
                Type = request.Dto.Type,
                BasePrice = request.Dto.BasePrice,
                IsActive = request.Dto.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);

            return entity.Id;
        }
    }
}
