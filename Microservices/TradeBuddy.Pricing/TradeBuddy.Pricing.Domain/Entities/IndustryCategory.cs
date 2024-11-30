using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Pricing.Domain.Entities
{
    public class IndustryCategory : BaseEntity<int>
    {
        public string Name { get; set; } // نام دسته‌بندی صنفی
        public string Description { get; set; } // توضیحات
        public bool IsActive { get; set; } // وضعیت فعال/غیرفعال
        public DateTime CreatedAt { get; set; } // زمان ایجاد
        public DateTime UpdatedAt { get; set; } // زمان آخرین ویرایش
    }
}
