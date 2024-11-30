using MediatR;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.Application.Commands
{
    public record CreatePricingPlanCommand(PricingPlanCreateDto Dto) : IRequest<int>;
}
