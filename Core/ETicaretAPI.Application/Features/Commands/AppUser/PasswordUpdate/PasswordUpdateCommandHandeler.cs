using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Exceptions;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser.PasswordUpdate
{
    public class PasswordUpdateCommandHandeler : IRequestHandler<PasswordUpdateCommandRequest, PasswordUpdateCommandResponse>
    {
        readonly IUserService _userService;

        public PasswordUpdateCommandHandeler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<PasswordUpdateCommandResponse> Handle(PasswordUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
            {
                throw new PasswordChangeFailedException("Please be sure your passwords match.");
            }
            else
            {
                await _userService.PasswordUpdateAsync(request.UserId, request.ResetToken, request.Password);
            }
            return new();
        }
    }
}
