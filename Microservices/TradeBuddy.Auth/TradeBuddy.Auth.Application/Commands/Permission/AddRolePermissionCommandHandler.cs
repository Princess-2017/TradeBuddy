using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TradeBuddy.Auth.Application.Commands.User;
using TradeBuddy.Auth.Application.Dto;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.Interfaces;
using TradeBuddy.Auth.Domain.ValueObjects;
using TradeBuddy.Business.Application.Queries.User;
using TradeBuddy.Review.Application.Exceptions;

namespace TradeBuddy.Auth.Application.Commands.Permission
{
    public class AddRolePermissionCommandHandler : IRequestHandler<AddRolePermissionCommand,Guid>
    {
        private readonly IRepository<RolePermission, Guid> _rolePermissionRepository;
        private readonly IRepository<Role, Guid> _roleRepository;
        private readonly IRepository<TradeBuddy.Auth.Domain.Entities.Permission, Guid> _permissionRepository;

        public AddRolePermissionCommandHandler(
            IRepository<RolePermission, Guid> rolePermissionRepository,
            IRepository<Role, Guid> roleRepository,
            IRepository<TradeBuddy.Auth.Domain.Entities.Permission, Guid> permissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<Guid> Handle(AddRolePermissionCommand request, CancellationToken cancellationToken)
        {
            // Validate that the Role exists
            var roleExists = await _roleRepository.ExistsAsync(r => r.Id == request.RoleId);
            //if (!roleExists)
            //    throw new NotFoundException($"Role with Id {request.RoleId} not found.");

            // Validate that the Permission exists
            var permissionExists = await _permissionRepository.ExistsAsync(p => p.Id == request.PermissionId);

            // Check if RolePermission already exists
            var rolePermissionExists = await _rolePermissionRepository.ExistsAsync(rp =>
                rp.RoleId == request.RoleId && rp.PermissionId == request.PermissionId);
            if (rolePermissionExists)
                throw new InvalidOperationException("This role already has the specified permission.");

            // Add new RolePermission
            var rolePermission = new RolePermission(request.RoleId, request.PermissionId);

            await _rolePermissionRepository.AddAsync(rolePermission);
            return rolePermission.Id;
        }
    }

}
