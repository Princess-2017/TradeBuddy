
namespace TradeBuddy.Pricing.Domain.Entities
{
    public class RatePlanFeature : BaseEntity<int>
    {
        public int? RatePlanId { get; set; } // شناسه نرخ‌نامه مرتبط
        public virtual RatePlan RatePlan { get; set; } // ارتباط با نرخ‌نامه
        public string FeatureName { get; set; } // نام ویژگی (مثلاً تعداد محصولات)
        public string FeatureValue { get; set; } // مقدار ویژگی (مثلاً "10 محصول")
        public decimal AdditionalPrice { get; set; } // هزینه اضافی (در صورت وجود)
    }

}
