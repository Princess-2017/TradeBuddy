using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Review.Domain.Entities
{
    public class LikeDislike : BaseEntity<Guid>
    {
        // Foreign key to Review
        public Guid ReviewId { get; set; }
        public virtual Review Review { get; set; }  // Navigation property to Review

        // Foreign key to User (assuming you have a User entity)
        public Guid UserId { get; set; }

        // Indicates whether the action is a like or a dislike
        public bool IsLike { get; set; }

    }
}
