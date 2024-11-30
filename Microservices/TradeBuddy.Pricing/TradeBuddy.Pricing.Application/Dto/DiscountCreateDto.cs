using TradeBuddy.Pricing.Domain.Enums;

namespace TradeBuddy.Pricing.Application.Dto
{
    public class DiscountCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DiscountType Type { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int? RatePlanId { get; set; }
        public int? PricingPlanId { get; set; }
    }

}
