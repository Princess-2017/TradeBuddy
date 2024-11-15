using TradeBuddy.Appointment.Domain.ValueObjects;

namespace TradeBuddy.Appointment.Domain.Entities
{
    public class TimeSlot
    {
        public Time Time { get; private set; } // زمان مشخص
        public TimeSpan Duration { get; private set; } // مدت زمان نوبت
        public AppointmentStatus Status { get; private set; } // وضعیت نوبت (در دسترس، رزرو شده و ...)

        // Constructor for creating TimeSlot
        public TimeSlot(Time time, TimeSpan duration, AppointmentStatus status)
        {
            Time = time;
            Duration = duration;
            Status = status;
        }

        // Parameterless constructor for EF Core
        private TimeSlot() { }
    }
}
