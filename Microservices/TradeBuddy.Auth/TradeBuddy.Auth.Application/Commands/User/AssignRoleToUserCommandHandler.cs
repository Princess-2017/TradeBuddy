using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.Interfaces;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, bool>
    {
        private readonly IRepository<UserRole, Guid> _userRoleRepository;

        public AssignRoleToUserCommandHandler(IRepository<UserRole, Guid> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<bool> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var userRole = new UserRole(request.UserId, request.RoleId);
            await _userRoleRepository.AddAsync(userRole);
            return true;
        }
    }
}
