using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;

namespace TaskManagerAPI.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<UserEntity?> GetUserAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username &&
                u.HashedPassword == password);
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _context.Users.ToListAsync() ?? [];
        }

        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
