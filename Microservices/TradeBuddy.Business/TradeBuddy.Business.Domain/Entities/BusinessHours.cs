using System;
using System.Collections.Generic;
using TradeBuddy.Business.Domain.ValueObjects;

namespace TradeBuddy.Business.Domain.Entities
{
    public class BusinessHours : BaseEntity<Guid>
    {
        public Guid BusinessId { get; private set; } // Foreign key
        public virtual Business Business { get; private set; } // Navigation property
        public virtual List<WorkingDay> WorkingDays { get; private set; } // Collection of WorkingDays
        public virtual List<TimeSlot> TimeSlots { get; private set; } // Collection of TimeSlots

        public BusinessHours()
        {
            WorkingDays = new List<WorkingDay>();
            TimeSlots = new List<TimeSlot>();
        }
    }
}
