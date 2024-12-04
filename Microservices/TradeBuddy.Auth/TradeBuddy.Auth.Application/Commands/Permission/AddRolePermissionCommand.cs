using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Application.Commands.Permission
{
    public class AddRolePermissionCommand : IRequest<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public AddRolePermissionCommand(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }
    }

}
