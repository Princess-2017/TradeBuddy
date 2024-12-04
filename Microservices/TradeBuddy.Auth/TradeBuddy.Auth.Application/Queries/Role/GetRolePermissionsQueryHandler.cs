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


namespace TradeBuddy.Auth.Application.Queries.Role
{
    public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, IEnumerable<IdTitleDto>>
    {
        private readonly IRepository<RolePermission, Guid> _rolePermissionRepository;

        public GetRolePermissionsQueryHandler(IRepository<RolePermission, Guid> rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<IEnumerable<IdTitleDto>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            // دریافت مجوزهای مربوط به نقش
            var permissions = await _rolePermissionRepository.GetAllAsync();
            return permissions
                .Where(rp => rp.RoleId == request.RoleId)
                .Select(rp => new IdTitleDto
                {
                    Id = rp.Id,
                    Title = rp.Role.Name
                })
                .ToList();
        }
    }

}
