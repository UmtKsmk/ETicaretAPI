using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Services.Configurations;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        readonly IApplicationService _applicationService;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly IEndpointWriteRepository _endpointWriteRepository;
        readonly IMenuReadRepository _menuReadRepository;
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly RoleManager<AppRole> _roleManager;

        public AuthorizationEndpointService(
            IEndpointReadRepository endpointReadRepository,
            IEndpointWriteRepository endpointWriteRepository,
            IApplicationService applicationService,
            IMenuWriteRepository menuWriteRepository,
            IMenuReadRepository menuReadRepository,
            RoleManager<AppRole> roleManager)
        {
            _endpointReadRepository = endpointReadRepository;
            _endpointWriteRepository = endpointWriteRepository;
            _applicationService = applicationService;
            _menuWriteRepository = menuWriteRepository;
            _menuReadRepository = menuReadRepository;
            _roleManager = roleManager;
        }

        public async Task AssaignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
        {
            Menu _menu = await _menuReadRepository.GetSingleAsync(m => m.Name == menu);
            if (_menu == null)
            {
                await _menuWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Name = menu,
                });

                await _menuWriteRepository.SaveAsync();
            }

            Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.Menu).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
            if (endpoint == null)
            {
                var action = _applicationService.GetAuthorizeDefinitionEndpoints(type)
                    .FirstOrDefault(m => m.Name == menu)
                    ?.Actions.FirstOrDefault(e => e.Code == code);

                endpoint = new()
                {
                    Id = Guid.NewGuid(),
                    Code = code,
                    ActionType = action.ActionType,
                    HttpType = action.HttpType,
                    Definition = action.Definition,
                };

                await _endpointWriteRepository.AddAsync(endpoint);
                await _endpointWriteRepository.SaveAsync();
            }

            var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

            foreach (var role in appRoles)
                endpoint.Roles.Add(role);

            await _endpointWriteRepository.SaveAsync();
        }
    }
}
