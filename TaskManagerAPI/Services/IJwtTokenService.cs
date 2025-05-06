using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Services
{
    public interface IJwtTokenService
    {
        string Generate(UserEntity user);
    }
}