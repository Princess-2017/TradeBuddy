using MediatR;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetServicePackageItemByIdQuery : IRequest<ServicePackageItemDto>
    {
        public int Id { get; set; }
    }
}
