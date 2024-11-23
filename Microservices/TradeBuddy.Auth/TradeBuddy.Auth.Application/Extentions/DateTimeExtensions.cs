using System;
using PersianDateTime;

namespace TradeBuddy.Review.Application.Exceptions
{
    public static class DateTimeExtensions
    {
        public static string ToPersianDateString(this DateTime dateTime)
        {
            return new PersianDateTime(dateTime).ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
