using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Pricing.Domain.Enums
{
    public enum PricingPlanType
    {
        ProductPromotion = 1,     // تبلیغ محصول
        CategoryPromotion = 2,    // تبلیغ دسته‌بندی
        BusinessSlider = 3,       // اسلایدر صفحه اصلی
        AppointmentBooking = 4,   // نوبت‌دهی آنلاین
        LadderPromotion = 5       // نردبان لیست دسته‌بندی‌ها
    }

}
