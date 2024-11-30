using MediatR;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetServicePackageItemsByPackageIdQuery : IRequest<List<ServicePackageItemDto>>
    {
        public int ServicePackageId { get; set; }
    }
}
