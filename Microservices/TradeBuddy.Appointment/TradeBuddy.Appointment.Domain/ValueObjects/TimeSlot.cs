
namespace TradeBuddy.Appointment.Domain.ValueObjects
{
    public class TimeSlot
    {
        public Time StartTime { get; }
        public Time EndTime { get; }
        public TimeSpan Duration { get; } // مدت زمان نوبت

        public TimeSlot(Time startTime, Time endTime)
        {
            if (endTime.Hour < startTime.Hour || (endTime.Hour == startTime.Hour && endTime.Minute <= startTime.Minute))
                throw new ArgumentException("End time must be after start time.");

            StartTime = startTime;
            EndTime = endTime;
            Duration = new TimeSpan(endTime.Hour - startTime.Hour, endTime.Minute - startTime.Minute, 0);
        }

        public override bool Equals(object obj)
        {
            return obj is TimeSlot other && StartTime.Equals(other.StartTime) && EndTime.Equals(other.EndTime);
        }

        public override int GetHashCode()
        {
            return StartTime.GetHashCode() ^ EndTime.GetHashCode();
        }
    }

}
