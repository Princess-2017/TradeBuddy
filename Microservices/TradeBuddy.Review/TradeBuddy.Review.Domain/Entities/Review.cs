using TradeBuddy.Review.Domain.ValueObjects;
using TradeBuddy.Review.Domain.Enums;

namespace TradeBuddy.Review.Domain.Entities
{
    public class Review : BaseEntity<Guid>  // Use Guid as the base entity type
    {
        public Guid BusinessId { get; private set; } // شناسه کسب‌وکار
        public Guid UserId { get; private set; } // شناسه کاربر
        public Rating Rating { get; set; } // امتیاز (Value Object)
        public string Comment { get; private set; } // متن نظر
        public ReviewType Type { get; private set; } // نوع نظر (Business, Product, Service)

        // Optional references for specific products or services
        public Guid? ProductId { get; private set; }  // This can be null if the review is for a business
        public Guid? ServiceId { get; private set; }  // This can be null if the review is for a business

        // Navigation property for Like/Dislike
        public virtual ICollection<LikeDislike> LikeDislikes { get; set; }

        // Constructor for initializing a new review
        public Review()
        {
            LikeDislikes = new List<LikeDislike>();
        }

        // Constructor with parameters for initial setup
        public Review(Guid businessId, Guid userId, Rating rating, string comment, ReviewType type, Guid? productId = null, Guid? serviceId = null)
        {
            Id = Guid.NewGuid();  // Initialize Id with a new GUID
            BusinessId = businessId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            Type = type;
            ProductId = productId;
            ServiceId = serviceId;
            CreateDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
            LikeDislikes = new List<LikeDislike>();
        }

        // Method to update the review content
        public void UpdateReview(Rating rating, string comment)
        {
            Rating = rating;
            Comment = comment;
            UpdateDate = DateTime.UtcNow;
        }

        // Method to add a like or dislike to the review
        public void AddLikeDislike(Guid userId, bool isLike)
        {
            var likeDislike = LikeDislikes.FirstOrDefault(ld => ld.UserId == userId);

            if (likeDislike == null)
            {
                // If no existing like/dislike from this user, add a new one
                LikeDislikes.Add(new LikeDislike
                {
                    UserId = userId,
                    ReviewId = this.Id, // Referencing the Guid Id here
                    IsLike = isLike
                });
            }
            else
            {
                // Update the existing like/dislike
                likeDislike.IsLike = isLike;
                SetUpdateDate(); // This will update the UpdateDate
            }
        }

        // Method to get the total likes for this review
        public int GetTotalLikes()
        {
            return LikeDislikes.Count(ld => ld.IsLike);
        }

        // Method to get the total dislikes for this review
        public int GetTotalDislikes()
        {
            return LikeDislikes.Count(ld => !ld.IsLike);
        }
    }
}
