using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Auth.Application.Commands.User;
using TradeBuddy.Auth.Application.Queries.Role;
using TradeBuddy.Auth.Application.Queries.User;

namespace TradeBuddy.Auth.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleCommand command)
        {
            var roleId = await _mediator.Send(command);
            return Ok(new { RoleId = roleId });
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleToUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(Guid userId)
        {
            var roles = await _mediator.Send(new GetUserRolesQuery(userId));
            return Ok(roles);
        }

        [HttpGet("role-permissions/{roleId}")]
        public async Task<IActionResult> GetRolePermissions(Guid roleId)
        {
            var permissions = await _mediator.Send(new GetRolePermissionsQuery(roleId));
            return Ok(permissions);
        }
    }

}
