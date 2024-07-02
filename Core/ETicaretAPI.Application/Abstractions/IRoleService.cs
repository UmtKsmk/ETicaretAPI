namespace ETicaretAPI.Application.Abstractions
{
    public interface IRoleService
    {
        (object, int) GetAllRoles(int page, int size);
        Task<(string id, string roleName)> GetRoleById(string id);
        Task<bool> CreateRole(string roleName);
        Task<bool> DeleteRole(string id);
        Task<bool> UpdateRole(string id, string roleName);
    }
}
