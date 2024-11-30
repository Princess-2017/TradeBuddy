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

    public class GetServicePackagesQueryHandler : IRequestHandler<GetServicePackagesQuery, List<ServicePackageDto>>
    {
        private readonly IRepository<ServicePackage,int> _servicePackageRepository;

        public GetServicePackagesQueryHandler(IRepository<ServicePackage,int> servicePackageRepository)
        {
            _servicePackageRepository = servicePackageRepository;
        }

        public async Task<List<ServicePackageDto>> Handle(GetServicePackagesQuery request, CancellationToken cancellationToken)
        {
            // تعریف فیلترهای شرطی
            Expression<Func<ServicePackage, bool>> filter = x => true; // به صورت پیش‌فرض همه را بگیرد

            if (request.IsActive.HasValue)
                filter = filter.And(x => x.IsActive == request.IsActive.Value);

            if (request.StartDate.HasValue)
                filter = filter.And(x => x.StartDate >= request.StartDate.Value);

            if (request.EndDate.HasValue)
                filter = filter.And(x => x.EndDate <= request.EndDate.Value);

            // دریافت داده‌ها با استفاده از متد SearchAsync
            var servicePackages = await _servicePackageRepository.SearchAsync(filter);

            return servicePackages.Select(x => new ServicePackageDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                BasePrice = x.BasePrice,
                FinalPrice = x.FinalPrice,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsActive = x.IsActive
            }).ToList();
        }
    }
}

