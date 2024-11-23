using System;
using System.Globalization;

namespace TradeBuddy.Review.Application.Exceptions
{

    public static class DateTimeExtensions
    {
        public static string ToPersianDateString(this DateTime dateTime)
        {
            var persianCalendar = new PersianCalendar();

            // استخراج سال، ماه و روز به صورت جداگانه
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            // قالب‌بندی رشته
            return $"{year:0000}/{month:00}/{day:00} {dateTime:HH:mm:ss}";
        }
    }

}
