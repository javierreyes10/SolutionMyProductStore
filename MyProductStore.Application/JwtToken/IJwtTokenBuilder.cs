using MyProductStore.Core.Entities;

namespace MyProductStore.Application.JwtToken
{
    public interface IJwtTokenBuilder
    {
        string BuildToken(User user);
    }
}
