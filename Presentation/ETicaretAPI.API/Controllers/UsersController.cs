using ETicaretAPI.Application.Features.Commands.AppUser.CreateUser;
using ETicaretAPI.Application.Features.Commands.AppUser.PasswordUpdate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("password-update")]
        public async Task<IActionResult> PasswordUpdate([FromBody] PasswordUpdateCommandRequest passwordUpdateCommandRequest)
        {
            PasswordUpdateCommandResponse response = await _mediator.Send(passwordUpdateCommandRequest);
            return Ok(response);
        }
    }
}
