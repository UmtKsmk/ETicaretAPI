using T = ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        T.Token CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
