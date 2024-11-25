using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Review.Domain.ValueObjects;

namespace TradeBuddy.Review.Domain.Entities
{
    public class Review : BaseEntity<long>
    {
        public Guid BusinessId { get; private set; } // شناسه کسب‌وکار
        public Guid UserId { get; private set; } // شناسه کاربر
        public Rating Rating { get; set; } // امتیاز (Value Object)
        public string Comment { get; private set; } // متن نظر

        public Review(){}

        // سازنده برای مقداردهی اولیه
        public Review(Guid businessId, Guid userId, Rating rating, string comment)
        {
            BusinessId = businessId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            CreateDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }

        // متدی برای به‌روزرسانی نظر
        public void UpdateReview(Rating rating, string comment)
        {
            Rating = rating;
            Comment = comment;
            UpdateDate = DateTime.UtcNow;
        }
    }

}
