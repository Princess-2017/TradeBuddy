using TradeBuddy.Pricing.Domain.Enums;

namespace TradeBuddy.Pricing.Application.Dto
{
    public class PricingPlanCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PricingPlanType Type { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsActive { get; set; }
    }

}
