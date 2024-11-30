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
    public class CreateServicePackageHandler : IRequestHandler<CreateServicePackageCommand, int>
    {
        private readonly IRepository<ServicePackage, int> _repository;

        public CreateServicePackageHandler(IRepository<ServicePackage, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateServicePackageCommand request, CancellationToken cancellationToken)
        {
            var entity = new ServicePackage
            {
                Name = request.Name,
                Description = request.Description,
                BasePrice = request.BasePrice,
                DiscountPercentage = request.DiscountPercentage,
                FinalPrice = request.FinalPrice,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);
            return entity.Id;
        }
    }
}
