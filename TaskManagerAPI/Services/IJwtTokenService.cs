using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserEntity user);
    }
}