using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Auth.Application.Commands.Permission;
using TradeBuddy.Auth.Application.Queries.Role;

namespace TradeBuddy.Auth.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolePermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolePermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Add Permission
        [HttpPost("add-permission")]
        public async Task<IActionResult> AddPermission([FromBody] AddPermissionCommand command)
        {
            if (command == null || string.IsNullOrEmpty(command.Name))
                return BadRequest("Invalid permission details.");

            var permissionId = await _mediator.Send(command);
            return Ok(new { PermissionId = permissionId });
        }

        // Add Role Permission
        [HttpPost("add-role-permission")]
        public async Task<IActionResult> AddRolePermission([FromBody] AddRolePermissionCommand command)
        {
            if (command == null || command.RoleId == Guid.Empty || command.PermissionId == Guid.Empty)
                return BadRequest("Invalid role or permission details.");

            await _mediator.Send(command);
            return Ok("Permission successfully added to role.");
        }

        // Get Permissions of a Role
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRolePermissions(Guid roleId)
        {
            if (roleId == Guid.Empty)
                return BadRequest("RoleId is required.");

            var permissions = await _mediator.Send(new GetRolePermissionsQuery(roleId));
            return Ok(permissions);
        }
    }

}
