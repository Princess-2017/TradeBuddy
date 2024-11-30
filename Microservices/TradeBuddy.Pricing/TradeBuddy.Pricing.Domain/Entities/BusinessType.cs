
namespace TradeBuddy.Pricing.Domain.Entities
{
    public class BusinessType : BaseEntity<int>
    {
        public string Name { get; set; } // نام (مثلاً فروشگاهی یا خدماتی)
        public string Description { get; set; } // توضیحات
        public bool IsActive { get; set; } // وضعیت فعال/غیرفعال
        public DateTime CreatedAt { get; set; } // زمان ایجاد
        public DateTime UpdatedAt { get; set; } // زمان آخرین ویرایش
    }

}
