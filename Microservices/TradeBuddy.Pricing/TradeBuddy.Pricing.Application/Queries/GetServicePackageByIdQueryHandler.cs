using MediatR;
using TradeBuddy.Pricing.Domain.Interfaces;
using TradeBuddy.Pricing.Application.Dto;
using TradeBuddy.Pricing.Domain.Entities;

namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetServicePackageByIdQueryHandler : IRequestHandler<GetServicePackageByIdQuery, ServicePackageDto>
    {
        private readonly IRepository<ServicePackage,int> _servicePackageRepository;

        public GetServicePackageByIdQueryHandler(IRepository<ServicePackage,int> servicePackageRepository)
        {
            _servicePackageRepository = servicePackageRepository;
        }

        public async Task<ServicePackageDto> Handle(GetServicePackageByIdQuery request, CancellationToken cancellationToken)
        {
            var servicePackage = await _servicePackageRepository.GetByIdAsync(request.Id);

            if (servicePackage == null)
                return null;

            // تبدیل ServicePackage به DTO
            return new ServicePackageDto
            {
                Id = servicePackage.Id,
                Name = servicePackage.Name,
                Description = servicePackage.Description,
                BasePrice = servicePackage.BasePrice,
                FinalPrice = servicePackage.FinalPrice,
                StartDate = servicePackage.StartDate,
                EndDate = servicePackage.EndDate,
                IsActive = servicePackage.IsActive
            };
        }
    }
}

