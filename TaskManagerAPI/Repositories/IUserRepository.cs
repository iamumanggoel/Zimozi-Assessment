using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;

namespace TaskManagerAPI.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity user);
        Task<List<UserEntity>> GetAllUsers();
        Task<UserEntity?> GetUserAsync(string username, string password);
    }
}