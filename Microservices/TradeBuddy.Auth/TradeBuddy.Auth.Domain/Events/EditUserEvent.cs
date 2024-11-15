using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.Events
{
    public class EditUserEvent
    {
        public Guid UserId { get; }
        public string UpdatedBy { get; }
        public DateTime UpdatedAt { get; }

        public EditUserEvent(Guid userId, string updatedBy)
        {
            UserId = userId;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
