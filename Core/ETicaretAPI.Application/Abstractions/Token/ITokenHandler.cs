using ETicaretAPI.Domain.Entities.Identity;
using T = ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        T.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
