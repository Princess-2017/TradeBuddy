using MediatR;
using TradeBuddy.Pricing.Application.Commands;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Handlers
{
    public class CreateServicePackageCommandHandler : IRequestHandler<CreateServicePackageCommand, int>
    {
        private readonly IRepository<ServicePackage,int> _servicePackageRepository; // Repository for ServicePackage
        private readonly IRepository<ServicePackageItem,int> _servicePackageItemRepository; // Repository for ServicePackageItem

        public CreateServicePackageCommandHandler(
            IRepository<ServicePackage,int> servicePackageRepository,
            IRepository<ServicePackageItem,int> servicePackageItemRepository)
        {
            _servicePackageRepository = servicePackageRepository;
            _servicePackageItemRepository = servicePackageItemRepository;
        }

        public async Task<int> Handle(CreateServicePackageCommand request, CancellationToken cancellationToken)
        {
            // Step 1: Create the ServicePackage
            var servicePackage = new ServicePackage
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

            // Step 2: Add the ServicePackage to the repository
            await _servicePackageRepository.AddAsync(servicePackage);

            // Step 3: Create and add ServicePackageItems
            if (request.Items != null)
            {
                foreach (var item in request.Items)
                {
                    var servicePackageItem = new ServicePackageItem
                    {
                        ServicePackageId = servicePackage.Id, // Associate with the created ServicePackage
                        RatePlanId = item.RatePlanId,
                        PricingPlanId = item.PricingPlanId,
                        Quantity = item.Quantity,
                        AdditionalPrice = item.AdditionalPrice
                    };

                    await _servicePackageItemRepository.AddAsync(servicePackageItem);
                }
            }

            return servicePackage.Id;  // Return the created ServicePackage's ID
        }
    }
}
