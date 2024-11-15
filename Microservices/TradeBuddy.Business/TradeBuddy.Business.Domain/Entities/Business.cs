using System;
using System.Collections.Generic;

namespace TradeBuddy.Business.Domain.Entities
{
    public class Business : BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid BusinessTypeId { get; private set; } // Foreign key to BusinessType
        public virtual BusinessType BusinessType { get; private set; } // Navigation property
        public virtual List<Service> Services { get; private set; }

        public Business(string name, string description, Guid businessTypeId, string createdBy)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            BusinessTypeId = businessTypeId;
            CreateBy = createdBy;
            Services = new List<Service>();
        }

        public Business() // Parameterless constructor for EF
        {
            Services = new List<Service>();
        }

        public void AddService(Service service)
        {
            Services.Add(service);
        }
    }
}
