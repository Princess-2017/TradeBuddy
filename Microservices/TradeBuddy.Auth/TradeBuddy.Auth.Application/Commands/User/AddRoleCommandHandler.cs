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
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Guid>
    {
        private readonly IRepository<Role, Guid> _roleRepository;

        public AddRoleCommandHandler(IRepository<Role, Guid> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Guid> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var newRole = new Role(Guid.NewGuid(), request.RoleName);
            await _roleRepository.AddAsync(newRole);
            return newRole.Id;
        }
    }
}
