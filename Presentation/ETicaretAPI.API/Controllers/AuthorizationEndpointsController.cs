using ETicaretAPI.Application.Features.Commands.AuthorizationEndpoint.AssaignRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AssaignRoleEndpoint(AssaignRoleEndpointCommandRequest assaignRoleEndpointCommandRequest)
        {
            assaignRoleEndpointCommandRequest.Type = typeof(Program);
            AssaignRoleEndpointCommandResponse response = await _mediator.Send(assaignRoleEndpointCommandRequest);
            return Ok(response);
        }
    }
}
