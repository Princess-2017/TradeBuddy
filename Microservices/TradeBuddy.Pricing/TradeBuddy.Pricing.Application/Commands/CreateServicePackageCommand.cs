using MediatR;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreateServicePackageCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateServicePackageItemCommand> Items { get; set; }  // Include items here
    }

    public class CreateServicePackageItemCommand
    {
        public int? RatePlanId { get; set; }
        public int? PricingPlanId { get; set; }
        public int Quantity { get; set; }
        public decimal AdditionalPrice { get; set; }
    }
}


