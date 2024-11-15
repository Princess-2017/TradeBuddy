using System;
using TradeBuddy.Notification.Domain.Entities;

namespace TradeBuddy.Notification.Domain.Entities
{
    public class Notification : BaseEntity<Guid>
    {
        public string Message { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime SentDate { get; private set; }
        public bool IsSent { get; private set; }

        public Notification(string message, string email, string phone)
        {
            Id = Guid.NewGuid();
            Message = message;
            Email = email;
            Phone = phone;
            SentDate = DateTime.UtcNow;
            IsSent = false; // به صورت پیش‌فرض نوتیفیکیشن ارسال نشده است
        }

        public void MarkAsSent()
        {
            IsSent = true;
            SentDate = DateTime.UtcNow; // زمان ارسال نوتیفیکیشن
        }
    }
}
