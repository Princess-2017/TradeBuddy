using MediatR;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.Application.Commands
{
    public record CreateDiscountCommand(DiscountCreateDto Dto) : IRequest<int>;
}
