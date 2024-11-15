using System;

namespace TradeBuddy.Business.Domain.ValueObjects
{
    public class Time
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }

        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour), "Hour must be between 0 and 23.");
            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException(nameof(minute), "Minute must be between 0 and 59.");

            Hour = hour;
            Minute = minute;
        }

        // Parameterless constructor for EF
        private Time() { }

        public override bool Equals(object obj)
        {
            return obj is Time other && Hour == other.Hour && Minute == other.Minute;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hour, Minute);
        }
    }
}
