using MediatR;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreateRatePlanCommandHandler : IRequestHandler<CreateRatePlanCommand, int>
    {
        private readonly IRepository<RatePlan, int> _repository;

        public CreateRatePlanCommandHandler(IRepository<RatePlan, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateRatePlanCommand request, CancellationToken cancellationToken)
        {
            var entity = new RatePlan
            {
                Name = request.Dto.Name,
                Price = request.Dto.Price,
                BusinessTypeId = request.Dto.BusinessTypeId,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);

            return entity.Id;
        }
    }
}
