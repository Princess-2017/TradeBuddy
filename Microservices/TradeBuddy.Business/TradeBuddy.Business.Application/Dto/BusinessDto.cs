using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Dto
{
    public class BusinessDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid City { get; set; }
        public Guid State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Guid BusinessTypeId { get; set; }
        public Guid BusinessCategoryId { get; set; }
        // Review Summary (Read-Only)
        public int TotalReviews { get; set; } // تعداد کل نظرات
        public double AverageRating { get; set; } // میانگین امتیاز
    }

}
