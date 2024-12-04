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
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, Guid>
    {
        private readonly IRepository<TradeBuddy.Auth.Domain.Entities.Permission, Guid> _permissionRepository;

        public AddPermissionCommandHandler(IRepository<TradeBuddy.Auth.Domain.Entities.Permission, Guid> permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Guid> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var newPermission = new TradeBuddy.Auth.Domain.Entities.Permission(
                Guid.NewGuid(),
                request.Name,
                request.ObjectType,
                request.ObjectKey,
                request.Action);
            await _permissionRepository.AddAsync(newPermission);
            return newPermission.Id;
        }
    }

}
