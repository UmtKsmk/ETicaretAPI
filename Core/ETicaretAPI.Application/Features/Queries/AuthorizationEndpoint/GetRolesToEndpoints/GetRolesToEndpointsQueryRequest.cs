﻿using MediatR;

namespace ETicaretAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints
{
    public class GetRolesToEndpointsQueryRequest : IRequest<GetRolesToEndpointsQueryResponse>
    {
        public string Code { get; set; }
        public string Menu { get; set; }
    }
}
