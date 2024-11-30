using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Pricing.Domain.Interfaces;
using TradeBuddy.Pricing.Application.Dto;
using TradeBuddy.Pricing.Domain.Entities;

namespace TradeBuddy.Pricing.Application.Queries
{

    public class GetServicePackageItemByIdQueryHandler : IRequestHandler<GetServicePackageItemByIdQuery, ServicePackageItemDto>
    {
        private readonly IRepository<ServicePackageItem,int> _servicePackageItemRepository;

        public GetServicePackageItemByIdQueryHandler(IRepository<ServicePackageItem,int> servicePackageItemRepository)
        {
            _servicePackageItemRepository = servicePackageItemRepository;
        }

        public async Task<ServicePackageItemDto> Handle(GetServicePackageItemByIdQuery request, CancellationToken cancellationToken)
        {
            var servicePackageItem = await _servicePackageItemRepository.GetByIdAsync(request.Id);

            if (servicePackageItem == null)
                return null;

            // تبدیل ServicePackageItem به DTO
            return new ServicePackageItemDto
            {
                Id = servicePackageItem.Id,
                ServicePackageId = servicePackageItem.ServicePackageId,
                RatePlanId = servicePackageItem.RatePlanId,
                PricingPlanId = servicePackageItem.PricingPlanId,
                Quantity = servicePackageItem.Quantity,
                AdditionalPrice = servicePackageItem.AdditionalPrice
            };
        }
    }
}

