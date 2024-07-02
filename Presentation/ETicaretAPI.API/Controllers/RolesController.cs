using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.Role.CreateRole;
using ETicaretAPI.Application.Features.Commands.Role.RemoveRole;
using ETicaretAPI.Application.Features.Commands.Role.UpdateRole;
using ETicaretAPI.Application.Features.Queries.Role.GetRoleById;
using ETicaretAPI.Application.Features.Queries.Role.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(Menu = "Roles", ActionType = ActionType.Reading, Definition = "Get Roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest getRolesQueryRequest)
        {
            GetRolesQueryResponse response = await _mediator.Send(getRolesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(Menu = "Roles", ActionType = ActionType.Reading, Definition = "Get Role By Id")]
        public async Task<IActionResult> GetRoles([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
        {
            GetRoleByIdQueryResponse response = await _mediator.Send(getRoleByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = "Roles", ActionType = ActionType.Writing, Definition = "Create Role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse response = await _mediator.Send(createRoleCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(Menu = "Roles", ActionType = ActionType.Updating, Definition = "Update Role")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(Menu = "Roles", ActionType = ActionType.Deleting, Definition = "Remove Role")]
        public async Task<IActionResult> DeleteRole([FromRoute] RemoveRoleCommandRequest removeRoleCommandRequest)
        {
            RemoveRoleCommandResponse response = await _mediator.Send(removeRoleCommandRequest);
            return Ok(response);
        }
    }
}
