
using TradeBuddy.Pricing.Domain.Enums;

namespace TradeBuddy.Pricing.Domain.Entities
{
    public class PricingPlan : BaseEntity<int>
    {
        public string Name { get; set; } // نام پلن (مثلاً نردبان، اسلایدر، تخفیف)
        public string Description { get; set; } // توضیحات
        public PricingPlanType Type { get; set; } // نوع پلن درآمدی
        public decimal BasePrice { get; set; } // قیمت پایه
        public bool IsActive { get; set; } // وضعیت فعال/غیرفعال
        public DateTime CreatedAt { get; set; } // زمان ایجاد
        public DateTime UpdatedAt { get; set; } // زمان آخرین ویرایش
    }
}
