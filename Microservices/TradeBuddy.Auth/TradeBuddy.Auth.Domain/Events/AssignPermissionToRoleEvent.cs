using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.Events
{
    public class AssignPermissionToRoleEvent
    {
        public Guid RoleId { get; }
        public Guid PermissionId { get; }
        public DateTime AssignedAt { get; }

        public AssignPermissionToRoleEvent(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
            AssignedAt = DateTime.UtcNow;
        }
    }
}
