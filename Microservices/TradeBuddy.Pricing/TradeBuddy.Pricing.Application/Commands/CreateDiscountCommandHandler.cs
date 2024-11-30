using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, int>
    {
        private readonly IRepository<Discount, int> _repository;

        public CreateDiscountCommandHandler(IRepository<Discount, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var entity = new Discount
            {
                Name = request.Dto.Name,
                Description = request.Dto.Description,
                Type = request.Dto.Type,
                Value = request.Dto.Value,
                StartDate = request.Dto.StartDate,
                EndDate = request.Dto.EndDate,
                IsActive = request.Dto.IsActive,
                RatePlanId = request.Dto.RatePlanId,
                PricingPlanId = request.Dto.PricingPlanId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);

            return entity.Id;
        }
    }

}
