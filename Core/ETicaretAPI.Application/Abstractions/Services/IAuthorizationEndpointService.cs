namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IAuthorizationEndpointService
    {
        public Task AssaignRoleEndpointAsync(string[] roles, string menu, string code, Type type);
    }
}
