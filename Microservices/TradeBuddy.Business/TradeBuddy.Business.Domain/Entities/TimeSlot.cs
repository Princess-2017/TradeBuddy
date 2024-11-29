using System;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.ValueObjects;
namespace TradeBuddy.Business.Domain.Entities;
public class TimeSlot : BaseEntity<Guid>
{
    public Time StartTime { get; private set; }
    public Time EndTime { get; private set; }

    public Guid BusinessHoursId { get; set; }
    // Foreign key to BusinessHours (virtual for lazy loading)
    public virtual BusinessHours BusinessHours { get; private set; }

    public TimeSlot(Time startTime, Time endTime)
    {
        if (startTime == null) throw new ArgumentNullException(nameof(startTime));
        if (endTime == null) throw new ArgumentNullException(nameof(endTime));
        if (endTime.Hour < startTime.Hour ||
           (endTime.Hour == startTime.Hour && endTime.Minute <= startTime.Minute))
        {
            throw new ArgumentException("End time must be after start time.", nameof(endTime));
        }

        Id = Guid.NewGuid(); // Automatically generate an ID for the time slot
        StartTime = startTime;
        EndTime = endTime;
    }

    // Parameterless constructor for EF Core
    private TimeSlot() { }
}
