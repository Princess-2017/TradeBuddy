using System;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities
{
    public class RolePermission : BaseEntity<RolePermissionId>
    {
        public RoleId RoleId { get; private set; }
        public PermissionId PermissionId { get; private set; }

        public RolePermission(RoleId roleId, PermissionId permissionId)
        {
            if (roleId == null || permissionId == null)
                throw new ArgumentNullException("RoleId and PermissionId cannot be null.");

            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
