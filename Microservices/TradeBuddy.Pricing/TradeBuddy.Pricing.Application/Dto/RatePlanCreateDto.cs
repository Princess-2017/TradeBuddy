namespace TradeBuddy.Pricing.Application.Dto
{
    public class RatePlanCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BusinessTypeId { get; set; }
    }
}
