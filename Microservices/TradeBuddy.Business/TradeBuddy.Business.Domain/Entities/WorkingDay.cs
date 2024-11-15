using System;

namespace TradeBuddy.Business.Domain.Entities
{
    public class WorkingDay
    {
        public Guid BusinessId { get; private set; } // Foreign key
        public DayOfWeek Day { get; private set; } // Day of the week
        public bool IsOpen { get; private set; } // Is this day open?
    }
}
