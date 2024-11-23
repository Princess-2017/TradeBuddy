using System;
using System.Collections.Generic;

namespace TradeBuddy.Business.Domain.Entities
{
    public class BusinessCategory : BaseEntity<Guid>
    {
        public string Name { get; private set; } // Category name
        public string Description { get; private set; } // Optional description

        // Navigation property for related businesses
        public virtual List<Business> Businesses { get; private set; }

        // Constructor for creating a new category
        public BusinessCategory(string name, string description = null)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            Businesses = new List<Business>();
        }

        // Parameterless constructor for EF
        protected BusinessCategory() { }

        // Method to update the category's name and description
        public void UpdateCategory(string name, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Update name
            Description = description; // Update description
        }
    }
}
