using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public record AddRoleCommand(string RoleName) : IRequest<Guid>;
}
