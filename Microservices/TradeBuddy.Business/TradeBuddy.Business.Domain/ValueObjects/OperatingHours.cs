using System;
using System.Collections.Generic;

namespace TradeBuddy.Business.Domain.ValueObjects
{
    public class OperatingHours : IEquatable<OperatingHours>
    {
        public Dictionary<DayOfWeek, TimeRange> HoursPerDay { get; private set; }

        public OperatingHours(Dictionary<DayOfWeek, TimeRange> hoursPerDay)
        {
            HoursPerDay = hoursPerDay ?? throw new ArgumentNullException(nameof(hoursPerDay));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OperatingHours);
        }

        public bool Equals(OperatingHours other)
        {
            return other != null &&
                   EqualityComparer<Dictionary<DayOfWeek, TimeRange>>.Default.Equals(HoursPerDay, other.HoursPerDay);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HoursPerDay);
        }
    }

    public class TimeRange
    {
        public TimeSpan Start { get; private set; }
        public TimeSpan End { get; private set; }

        public TimeRange(TimeSpan start, TimeSpan end)
        {
            if (start >= end)
                throw new ArgumentException("Start time must be earlier than end time");

            Start = start;
            End = end;
        }
    }
}
