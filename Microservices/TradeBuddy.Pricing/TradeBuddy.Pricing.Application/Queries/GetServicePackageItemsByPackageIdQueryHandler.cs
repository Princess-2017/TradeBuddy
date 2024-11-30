using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Pricing.Domain.Interfaces;
using TradeBuddy.Pricing.Application.Dto;
using TradeBuddy.Pricing.Domain.Entities;
using System.Linq.Expressions;
using TradeBuddy.Pricing.Application.Extentions;

namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetServicePackageItemsByPackageIdQueryHandler : IRequestHandler<GetServicePackageItemsByPackageIdQuery, List<ServicePackageItemDto>>
    {
        private readonly IRepository<ServicePackageItem, int> _servicePackageItemRepository;

        public GetServicePackageItemsByPackageIdQueryHandler(IRepository<ServicePackageItem, int> servicePackageItemRepository)
        {
            _servicePackageItemRepository = servicePackageItemRepository;
        }

        public async Task<List<ServicePackageItemDto>> Handle(GetServicePackageItemsByPackageIdQuery request, CancellationToken cancellationToken)
        {
            // ساخت فیلتر داینامیک
            Expression<Func<ServicePackageItem, bool>> filter = x => true; // فیلتر پیش‌فرض که همه رکوردها را می‌گیرد

            // افزودن فیلتر برای ServicePackageId
            if (request.ServicePackageId > 0)
            {
                filter = filter.And(x => x.ServicePackageId == request.ServicePackageId);
            }

            // استفاده از SearchAsync برای گرفتن داده‌ها با فیلتر
            var servicePackageItems = await _servicePackageItemRepository.SearchAsync(filter);

            // تبدیل نتایج به DTO
            return servicePackageItems.Select(x => new ServicePackageItemDto
            {
                Id = x.Id,
                ServicePackageId = x.ServicePackageId,
                RatePlanId = x.RatePlanId,
                PricingPlanId = x.PricingPlanId,
                Quantity = x.Quantity,
                AdditionalPrice = x.AdditionalPrice
            }).ToList();
        }
    }
}
