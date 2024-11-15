using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Reservation.Application.Common.Interfaces
{
    public interface IMessagingService
    {
        /// <summary>
        /// ارسال پیام به صف (queue) تعریف‌شده.
        /// </summary>
        /// <typeparam name="T">نوع پیام</typeparam>
        /// <param name="message">پیام مورد نظر برای ارسال</param>
        void Publish<T>(T message);

        /// <summary>
        /// دریافت پیام‌ها از صف (queue) تعریف‌شده و پردازش آن‌ها.
        /// </summary>
        /// <typeparam name="T">نوع پیام</typeparam>
        /// <param name="onMessageReceived">اکشنی که پیام دریافت شده را پردازش می‌کند</param>
        void Subscribe<T>(Action<T> onMessageReceived);
    }

}
