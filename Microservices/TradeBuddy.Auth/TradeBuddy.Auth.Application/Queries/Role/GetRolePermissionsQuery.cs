using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Auth.Application.Dto;

namespace TradeBuddy.Auth.Application.Queries.Role
{
    public record GetRolePermissionsQuery(Guid RoleId) : IRequest<IEnumerable<IdTitleDto>>;
}
