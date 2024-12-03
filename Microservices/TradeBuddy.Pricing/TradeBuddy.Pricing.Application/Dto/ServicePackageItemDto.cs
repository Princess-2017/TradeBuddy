using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Pricing.Application.Dto
{
    public class ServicePackageItemDto
    {
        public int Id { get; set; }
        public int? ServicePackageId { get; set; }
        public int? RatePlanId { get; set; }
        public int? PricingPlanId { get; set; }
        public int Quantity { get; set; }
        public decimal AdditionalPrice { get; set; }
    }
}
