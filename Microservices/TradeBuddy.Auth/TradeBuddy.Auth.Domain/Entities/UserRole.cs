using System;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities
{
    public class UserRole : BaseEntity<UserRoleId>
    {
        public UserId UserId { get; private set; }
        public RoleId RoleId { get; private set; }

        public UserRole(UserId userId, RoleId roleId)
        {
            if (userId == null || roleId == null)
                throw new ArgumentNullException("UserId and RoleId cannot be null.");

            UserId = userId;
            RoleId = roleId;
        }
    }
}
