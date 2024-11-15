using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.Events
{
    public class RoleAssignedEvent
    {
        public Guid UserId { get; }
        public Guid RoleId { get; }
        public DateTime AssignedAt { get; }

        public RoleAssignedEvent(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
            AssignedAt = DateTime.UtcNow;
        }
    }
}
