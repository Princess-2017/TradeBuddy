using TradeBuddy.Pricing.Domain.Enums;

namespace TradeBuddy.Pricing.Domain.Entities
{
    public class Discount : BaseEntity<int>
    {
        public string Name { get; set; } // نام تخفیف
        public string Description { get; set; } // توضیحات
        public DiscountType Type { get; set; } // نوع تخفیف (مثلاً درصدی یا ثابت)
        public decimal Value { get; set; } // مقدار تخفیف
        public DateTime StartDate { get; set; } // تاریخ شروع تخفیف
        public DateTime EndDate { get; set; } // تاریخ پایان تخفیف
        public bool IsActive { get; set; } // وضعیت فعال/غیرفعال
        public DateTime CreatedAt { get; set; } // زمان ایجاد
        public DateTime UpdatedAt { get; set; } // زمان آخرین ویرایش

        // ارتباط با نرخ‌نامه یا پلن درآمدی
        public int? RatePlanId { get; set; } // نرخ‌نامه مرتبط (در صورت وجود)
        public virtual RatePlan RatePlan { get; set; }
        public int? PricingPlanId { get; set; } // پلن درآمدی مرتبط (در صورت وجود)
        public virtual PricingPlan PricingPlan { get; set; }
    }

}
