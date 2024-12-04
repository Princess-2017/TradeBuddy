using System;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities
{
    public class UserRole : BaseEntity<Guid>
    {
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }

        public UserRole(Guid userId, Guid roleId)
        {
            if (userId == null || roleId == null)
                throw new ArgumentNullException("UserId and RoleId cannot be null.");

            UserId = userId;
            RoleId = roleId;
        }
    }
}
