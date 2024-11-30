using MediatR;
using TradeBuddy.Pricing.Application.Dto;


namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetServicePackageByIdQuery : IRequest<ServicePackageDto>
    {
        public int Id { get; set; }
    }
}
