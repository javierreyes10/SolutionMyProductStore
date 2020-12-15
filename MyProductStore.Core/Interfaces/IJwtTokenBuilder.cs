using MyProductStore.Core.Entities;

namespace MyProductStore.Core.Interfaces
{
    public interface IJwtTokenBuilder
    {
        string BuildToken(User user);
    }
}
