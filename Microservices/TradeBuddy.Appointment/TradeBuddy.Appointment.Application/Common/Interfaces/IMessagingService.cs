using System;
using System.Threading.Tasks;

namespace TradeBuddy.Appointment.Application.Common.Interfaces
{
    public interface IMessagingService
    {
        /// <summary>
        /// ارسال پیام به صف (queue) تعریف‌شده به صورت غیر همزمان.
        /// </summary>
        /// <typeparam name="T">نوع پیام</typeparam>
        /// <param name="message">پیام مورد نظر برای ارسال</param>
        Task PublishAsync<T>(T message);

        /// <summary>
        /// دریافت پیام‌ها از صف (queue) تعریف‌شده و پردازش آن‌ها به صورت غیر همزمان.
        /// </summary>
        /// <typeparam name="T">نوع پیام</typeparam>
        /// <param name="onMessageReceived">اکشنی که پیام دریافت شده را پردازش می‌کند</param>
        Task SubscribeAsync<TMessage>(Func<TMessage, Task> onMessageReceived);
    }
}
