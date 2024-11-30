using MediatR;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetServicePackagesQuery : IRequest<List<ServicePackageDto>>
    {
        public bool? IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

