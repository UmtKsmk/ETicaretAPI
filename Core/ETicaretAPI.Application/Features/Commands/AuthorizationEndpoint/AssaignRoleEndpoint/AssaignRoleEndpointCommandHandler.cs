using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AuthorizationEndpoint.AssaignRole
{
    public class AssaignRoleEndpointCommandHandler : IRequestHandler<AssaignRoleEndpointCommandRequest, AssaignRoleEndpointCommandResponse>
    {
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public AssaignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<AssaignRoleEndpointCommandResponse> Handle(AssaignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            await _authorizationEndpointService.AssaignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
            return new()
            {

            };
        }
    }
}
