using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Auth.Application.Dto;

namespace TradeBuddy.Auth.Application.Queries.User
{
    public record GetUserRolesQuery(Guid UserId) : IRequest<IEnumerable<IdTitleDto>>;

}
