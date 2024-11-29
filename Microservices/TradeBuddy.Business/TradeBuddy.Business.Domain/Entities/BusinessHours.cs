using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeBuddy.Business.Domain.Entities
{
    public class BusinessHours : BaseEntity<Guid>
    {
        // Foreign key to Business
        [Column("BusinessId")]
        public Guid BusinessId { get; private set; }

        // Navigation to Business (virtual for lazy loading)
        public virtual Business Business { get; private set; }

        // Navigation to WorkingDays (virtual for lazy loading)
        public virtual List<WorkingDay> WorkingDays { get; private set; }

        // Navigation to TimeSlots (virtual for lazy loading)
        public virtual List<TimeSlot> TimeSlots { get; private set; }

        public BusinessHours()
        {
            WorkingDays = new List<WorkingDay>();
            TimeSlots = new List<TimeSlot>();
        }
    }
}
