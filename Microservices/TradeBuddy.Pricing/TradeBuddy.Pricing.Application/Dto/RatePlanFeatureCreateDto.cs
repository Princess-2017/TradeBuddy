namespace TradeBuddy.Pricing.Application.Dto
{
    public class RatePlanFeatureCreateDto
    {
        public int RatePlanId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureValue { get; set; }
        public decimal AdditionalPrice { get; set; }
    }

}
