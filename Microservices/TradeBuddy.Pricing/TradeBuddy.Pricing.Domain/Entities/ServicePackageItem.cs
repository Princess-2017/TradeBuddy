

namespace TradeBuddy.Pricing.Domain.Entities
{
    public class ServicePackageItem : BaseEntity<int>
    {
        public int? ServicePackageId { get; set; } // شناسه پکیج مرتبط
        public virtual ServicePackage ServicePackage { get; set; } // ارتباط با پکیج
        public int? RatePlanId { get; set; } // نرخ‌نامه مرتبط (در صورت وجود)
        public virtual RatePlan RatePlan { get; set; } // ارتباط با نرخ‌نامه
        public int? PricingPlanId { get; set; } // پلن درآمدی مرتبط (در صورت وجود)
        public virtual PricingPlan PricingPlan { get; set; } // ارتباط با پلن درآمدی
        public int Quantity { get; set; } // تعداد یا میزان استفاده از آیتم (مثلاً تعداد محصولات)
        public decimal AdditionalPrice { get; set; } // قیمت اضافی این آیتم در پکیج (در صورت وجود)
    }
}
