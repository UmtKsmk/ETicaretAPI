using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public (object, int) GetAllRoles(int page, int size)
        {
            var query = _roleManager.Roles;

            IQueryable<AppRole> rolesQuery = null;

            if (page != -1 && size != -1)
            {
                rolesQuery = query.Skip(page * size).Take(size);
            }
            else
            {
                rolesQuery = query;
            }

            return (rolesQuery.Select(r => new { r.Id, r.Name }), query.Count());
        }

        public async Task<(string id, string roleName)> GetRoleById(string id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
            return (id, role);
        }

        public async Task<bool> UpdateRole(string id, string roleName)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            role.Name = roleName;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> CreateRole(string roleName)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid().ToString(), Name = roleName });
            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string id)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(appRole);
            return result.Succeeded;
        }

    }
}
