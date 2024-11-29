using System;

namespace TradeBuddy.Business.Domain.Entities
{
    public class WorkingDay : BaseEntity<Guid>
    {
        public Guid BusinessId { get; private set; } // کلید خارجی
        public DateTime Date { get; private set; } // تاریخ خاص (مثلاً 24/4/1400)
        public bool IsOpen { get; private set; } // آیا این روز باز است؟

        // سازنده
        public WorkingDay(Guid businessId, DateTime date, bool isOpen)
        {
            Id = Guid.NewGuid();
            BusinessId = businessId;
            Date = date;
            IsOpen = isOpen;
        }

        // Constructor خالی برای EF
        private WorkingDay() { }
    }

}
