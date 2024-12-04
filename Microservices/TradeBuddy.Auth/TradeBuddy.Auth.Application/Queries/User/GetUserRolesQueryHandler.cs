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

namespace TradeBuddy.Auth.Application.Queries.User
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<IdTitleDto>>
    {
        private readonly IRepository<UserRole, Guid> _userRoleRepository;
        private readonly IRepository<TradeBuddy.Auth.Domain.Entities.Role, Guid> _roleRepository;

        public GetUserRolesQueryHandler(
            IRepository<UserRole, Guid> userRoleRepository,
            IRepository<TradeBuddy.Auth.Domain.Entities.Role, Guid> roleRepository)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<IdTitleDto>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            // دریافت نقش‌های کاربر از UserRole
            var userRoles = await _userRoleRepository.GetAllAsync();
            var userRoleIds = userRoles
                .Where(ur => ur.UserId == request.UserId)
                .Select(ur => ur.RoleId)
                .ToList();

            // دریافت نام نقش‌ها از Role
            var roles = await _roleRepository.GetAllAsync();
            return roles
                .Where(role => userRoleIds.Contains(role.Id))
                .Select(role => new IdTitleDto
                {
                    Id = role.Id,
                    Title = role.Name
                })
                .ToList();
        }
    }

}
