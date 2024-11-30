using MediatR;
using TradeBuddy.Pricing.Application.Dto;
namespace TradeBuddy.Pricing.Application.Commands
{
    public record CreateRatePlanCommand(RatePlanCreateDto Dto) : IRequest<int>;

}
