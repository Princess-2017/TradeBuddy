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
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        // Relationships
        public Guid BusinessTypeId { get; private set; } // Foreign key to BusinessType
        public Guid BusinessCategoryId { get; private set; } // Foreign key to BusinessCategory

        public virtual BusinessType BusinessType { get; private set; } // Navigation property
        public virtual BusinessCategory BusinessCategory { get; private set; } // Navigation property
        public virtual List<Service> Services { get; private set; }
        public virtual List<Media> MediaAttachments { get; private set; }

        // Review Summary (Read-Only)
        public int TotalReviews { get; private set; } // تعداد کل نظرات
        public double AverageRating { get; private set; } // میانگین امتیاز

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
            string city,
            string state,
            string postalCode,
            string country,
            decimal latitude,
            decimal longitude,
            Guid businessTypeId,
            Guid businessCategoryId,
            string createdBy)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Website = website;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
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
            MediaAttachments = new List<Media>();

            // Default review data
            TotalReviews = 0;
            AverageRating = 0;
        }

        public Business() // Parameterless constructor for EF
        {
            Services = new List<Service>();
            MediaAttachments = new List<Media>();
        }

        // متد برای بروزرسانی مشخصات کسب و کار
        public void UpdateDetails(string name, string description, string website, string email, string phone,
            string address, string city, string state, string postalCode, string country,
            decimal latitude, decimal longitude, Guid businessTypeId, Guid businessCategoryId)
        {
            Name = name;
            Description = description;
            Website = website;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
            BusinessTypeId = businessTypeId;
            BusinessCategoryId = businessCategoryId;
        }

        // Methods to update review summary (from external service)
        public void UpdateReviewSummary(int totalReviews, double averageRating)
        {
            TotalReviews = totalReviews;
            AverageRating = averageRating;
            UpdatedAt = DateTime.UtcNow;
        }

        // Other operational methods
        public void VerifyBusiness() => IsVerified = true;
    }
}
