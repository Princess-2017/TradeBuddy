using System;
using System.Collections.Generic;

namespace TradeBuddy.Business.Domain.Entities
{
    public class Business : BaseEntity<Guid>
    {
        // General Information
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Website { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        // Address Details
        public string Address { get; private set; }
        public Guid CityId { get; private set; } // Foreign key to City
        public Guid StateId { get; private set; } // Foreign key to State
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        // Relationships
        public Guid BusinessTypeId { get; private set; } // Foreign key to BusinessType
        public Guid BusinessCategoryId { get; private set; } // Foreign key to BusinessCategory

        public virtual BusinessType BusinessType { get; private set; } // Navigation property
        public virtual BusinessCategory BusinessCategory { get; private set; } // Navigation property
        public virtual City City { get; private set; } // Navigation property for City
        public virtual State State { get; private set; } // Navigation property for State
        public virtual List<Service> Services { get; private set; }
        public virtual ICollection<WorkingDay> WorkingDays { get; private set; } = new List<WorkingDay>();
        public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

        // Review Summary (Read-Only)
        public int TotalReviews { get; private set; } // Total number of reviews
        public double AverageRating { get; private set; } // Average rating

        // Operational Information
        public bool IsVerified { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Constructor
        public Business(
            string name,
            string description,
            string website,
            string email,
            string phone,
            string address,
            Guid cityId,
            Guid stateId,
            string postalCode,
            string country,
            decimal latitude,
            decimal longitude,
            Guid businessTypeId,
            Guid businessCategoryId,
            string createdBy)
        {
            Id = Guid.NewGuid(); // Sequential GUID (handled by database)
            Name = name;
            Description = description;
            Website = website;
            Email = email;
            Phone = phone;
            Address = address;
            CityId = cityId;
            StateId = stateId;
            PostalCode = postalCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
            BusinessTypeId = businessTypeId;
            BusinessCategoryId = businessCategoryId;
            CreateBy = createdBy;
            IsVerified = false; // Default to unverified
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            Services = new List<Service>();

            // Default review data
            TotalReviews = 0;
            AverageRating = 0;
        }

        public Business() // Parameterless constructor for EF
        {
            Services = new List<Service>();
        }

        // Method to update business details
        public void UpdateDetails(
            string name,
            string description,
            string website,
            string email,
            string phone,
            string address,
            Guid cityId,
            Guid stateId,
            string postalCode,
            string country,
            decimal latitude,
            decimal longitude,
            Guid businessTypeId,
            Guid businessCategoryId)
        {
            Name = name;
            Description = description;
            Website = website;
            Email = email;
            Phone = phone;
            Address = address;
            CityId = cityId;
            StateId = stateId;
            PostalCode = postalCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
            BusinessTypeId = businessTypeId;
            BusinessCategoryId = businessCategoryId;
            UpdatedAt = DateTime.UtcNow;
        }

        // Method to update review summary
        public void UpdateReviewSummary(int totalReviews, double averageRating)
        {
            TotalReviews = totalReviews;
            AverageRating = averageRating;
            UpdatedAt = DateTime.UtcNow;
        }

        // Operational method to verify the business
        public void VerifyBusiness()
        {
            IsVerified = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
  
}
