using System;

namespace TradeBuddy.Appointment.Domain.ValueObjects
{
    public class Time
    {
        public int Hour { get; }
        public int Minute { get; }

        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23) throw new ArgumentOutOfRangeException(nameof(hour));
            if (minute < 0 || minute > 59) throw new ArgumentOutOfRangeException(nameof(minute));

            Hour = hour;
            Minute = minute;
        }

        public static Time FromString(string timeString)
        {
            var parts = timeString.Split(':');
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out var hour) ||
                !int.TryParse(parts[1], out var minute))
            {
                throw new FormatException("Invalid time format. Expected format is HH:mm.");
            }

            return new Time(hour, minute);
        }

        public override string ToString()
        {
            return $"{Hour:D2}:{Minute:D2}";
        }

        public override bool Equals(object obj)
        {
            return obj is Time other && Hour == other.Hour && Minute == other.Minute;
        }

        public override int GetHashCode()
        {
            return (Hour * 60 + Minute).GetHashCode();
        }

        private Time() { }
    }
}
