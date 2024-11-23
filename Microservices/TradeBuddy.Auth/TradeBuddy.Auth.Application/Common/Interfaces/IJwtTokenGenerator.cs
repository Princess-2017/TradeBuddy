using TradeBuddy.Auth.Domain.Entities;

namespace TradeBuddy.Auth.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
