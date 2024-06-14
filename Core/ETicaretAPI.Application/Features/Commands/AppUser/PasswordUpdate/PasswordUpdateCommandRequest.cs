using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser.PasswordUpdate
{
    public class PasswordUpdateCommandRequest : IRequest<PasswordUpdateCommandResponse>
    {
        public string UserId { get; set; }
        public string ResetToken { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
