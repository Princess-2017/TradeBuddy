
namespace TradeBuddy.Pricing.Application.Dto
{
    public class ServicePackageCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }

}
