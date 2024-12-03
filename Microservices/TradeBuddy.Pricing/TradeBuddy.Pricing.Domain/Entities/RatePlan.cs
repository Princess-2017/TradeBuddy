

namespace TradeBuddy.Pricing.Domain.Entities
{
    public class RatePlan : BaseEntity<int>
    {
        public string Name { get; set; } // نام نرخ‌نامه
        public string Description { get; set; } // توضیحات
        public int? IndustryCategoryId { get; set; } // شناسه دسته‌بندی صنفی
        public virtual IndustryCategory IndustryCategory { get; set; } // ارتباط با دسته‌بندی صنفی
        public int? BusinessTypeId { get; set; } // شناسه نوع کسب‌وکار
        public virtual BusinessType BusinessType { get; set; } // ارتباط با نوع کسب‌وکار
        public TimeSpan? Duration { get; set; } // مدت زمان اعتبار نرخ‌نامه (اختیاری)
        public decimal Price { get; set; } // قیمت نرخ‌نامه
        public bool IsActive { get; set; } // وضعیت فعال/غیرفعال
        public DateTime CreatedAt { get; set; } // زمان ایجاد
        public DateTime UpdatedAt { get; set; } // زمان آخرین ویرایش
    }

}
