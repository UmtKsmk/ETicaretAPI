using ETicaretAPI.Application.Abstractions;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Role.RemoveRole
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommandRequest, RemoveRoleCommandResponse>
    {
        readonly IRoleService _roleService;

        public RemoveRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RemoveRoleCommandResponse> Handle(RemoveRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.DeleteRole(request.Id);
            return new()
            {
                Succeeded = result
            };
        }
    }
}
