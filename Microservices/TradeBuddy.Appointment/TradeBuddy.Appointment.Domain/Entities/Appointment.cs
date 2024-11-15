using TradeBuddy.Appointment.Domain.ValueObjects;

namespace TradeBuddy.Appointment.Domain.Entities
{
    public class Appointment : BaseEntity<AppointmentId>
    {
        public virtual BusinessId BusinessId { get; private set; } // شناسه کسب و کار
        public virtual CustomerId CustomerId { get; private set; } // شناسه مشتری
        public virtual Time Time { get; private set; } // زمان نوبت
        public DateTime AppointmentDate { get; private set; } // تاریخ نوبت
        public AppointmentStatus Status { get; private set; } // وضعیت نوبت
    }
}