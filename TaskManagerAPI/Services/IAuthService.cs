using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;

namespace TaskManagerAPI.Services
{
    public interface IAuthService
    {
        Task<List<UserResponse>> GetAllUsers();
        Task<LoginResponse?> Login(LoginRequest request);
        Task<UserEntity?> SignUp(LoginRequest request);
    }
}