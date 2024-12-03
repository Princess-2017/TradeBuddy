
namespace TradeBuddy.Pricing.Domain.Entities
{
    public class ServicePackage : BaseEntity<int>
    {
        public string Name { get; set; } // نام پکیج
        public string Description { get; set; } // توضیحات
        public decimal BasePrice { get; set; } // قیمت پایه پکیج
        public decimal? DiscountPercentage { get; set; } // درصد تخفیف (در صورت وجود)
        public decimal FinalPrice { get; set; } // قیمت نهایی با اعمال تخفیف
        public DateTime? StartDate { get; set; } // تاریخ شروع پکیج (در صورت زمان‌دار بودن)
        public DateTime? EndDate { get; set; } // تاریخ پایان پکیج (در صورت زمان‌دار بودن)
        public bool IsActive { get; set; } // وضعیت فعال/غیرفعال
        public DateTime CreatedAt { get; set; } // زمان ایجاد
        public DateTime UpdatedAt { get; set; } // زمان آخرین ویرایش

        // ارتباط با آیتم‌های داخل پکیج
        public virtual ICollection<ServicePackageItem> Items { get; set; } 
    }
}
