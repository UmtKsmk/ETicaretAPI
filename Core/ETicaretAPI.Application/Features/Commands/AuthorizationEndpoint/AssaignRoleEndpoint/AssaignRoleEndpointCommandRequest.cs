using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AuthorizationEndpoint.AssaignRole
{
    public class AssaignRoleEndpointCommandRequest : IRequest<AssaignRoleEndpointCommandResponse>
    {
        public string[] Roles { get; set; }
        public string Code { get; set; }
        public string Menu { get; set; }
        public Type Type { get; set; }
    }
}
