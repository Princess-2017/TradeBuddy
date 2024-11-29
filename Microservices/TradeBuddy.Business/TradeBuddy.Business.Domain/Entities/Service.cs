using System;
using System.Collections.Generic;
using TradeBuddy.Business.Domain.ValueObjects;

namespace TradeBuddy.Business.Domain.Entities
{
    public class Service : BaseEntity<Guid>
    {
        public string ServiceName { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<ServiceLocationType> ServiceLocationTypes { get; private set; } = new List<ServiceLocationType>();

        public Guid BusinessId { get; private set; } // Foreign key to Business
        public virtual Business Business { get; private set; } // Navigation property for Business

        // Time properties
        public int StartHour { get; private set; }
        public int StartMinute { get; private set; }
        public int EndHour { get; private set; }
        public int EndMinute { get; private set; }

        // Constructor for creating a new service
        public Service(string serviceName, decimal price, ServiceLocationType locationType, string createdBy, Time startTime, Time endTime, Guid businessId)
        {
            Id = Guid.NewGuid();
            ServiceName = serviceName;
            Price = price;
            ServiceLocationTypes.Add(locationType); // Add location type to the collection
            StartHour = startTime.Hour;
            StartMinute = startTime.Minute;
            EndHour = endTime.Hour;
            EndMinute = endTime.Minute;
            CreateBy = createdBy;
            BusinessId = businessId;
        }

        // Parameterless constructor for EF
        public Service() { }

        public Time StartTime => new Time(StartHour, StartMinute);
        public Time EndTime => new Time(EndHour, EndMinute);

        public void UpdateService(string serviceName, decimal price, ServiceLocationType locationType, Time startTime, Time endTime, string updatedBy)
        {
            ServiceName = serviceName;
            Price = price;
            ServiceLocationTypes.Clear(); // Clear previous location types if needed
            ServiceLocationTypes.Add(locationType); // Update with new location type
            StartHour = startTime.Hour;
            StartMinute = startTime.Minute;
            EndHour = endTime.Hour;
            EndMinute = endTime.Minute;
            Update(updatedBy);
        }
    }

}
