
using MediatR;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreateBusinessTypeCommandHandler : IRequestHandler<CreateBusinessTypeCommand, int>
    {
        private readonly IRepository<BusinessType,int> _repository;

        public CreateBusinessTypeCommandHandler(IRepository<BusinessType,int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBusinessTypeCommand request, CancellationToken cancellationToken)
        {
            var businessType = new BusinessType
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(businessType);
            return businessType.Id;
        }
    }
}
