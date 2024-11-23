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
        public int BusinessId { get; private set; } // شناسه کسب‌وکار
        public string UserId { get; private set; } // شناسه کاربر
        public Rating Rating { get; private set; } // امتیاز (Value Object)
        public string Comment { get; private set; } // متن نظر

        // سازنده برای مقداردهی اولیه
        public Review(int businessId, string userId, Rating rating, string comment)
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
