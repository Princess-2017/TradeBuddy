using System;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities
{
    public class RolePermission : BaseEntity<Guid>
    {
        public Guid RoleId { get; private set; }
        public Guid PermissionId { get; private set; }

        public virtual Role Role { get; private set; }

        public RolePermission(Guid roleId, Guid permissionId)
        {
            if (roleId == null || permissionId == null)
                throw new ArgumentNullException("RoleId and PermissionId cannot be null.");

            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
