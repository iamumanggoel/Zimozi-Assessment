using TaskManagerAPI.Entities;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Services
{
    public class AuthService(IUserRepository userRepo, IJwtTokenService jwtService) : IAuthService
    {
        private readonly IUserRepository _userRepo = userRepo;
        private readonly IJwtTokenService _jwtservice = jwtService;

        public async Task<LoginResponse?> Login(LoginRequest request)
        {
            //Validate User Credentials (Authentication)
            var user = await _userRepo.GetUserAsync(request.UserName, request.Password);
            if (user is null)
                return null;

            //Generate AuthToken
            var token = _jwtservice.GenerateToken(user);

            return new LoginResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = token,
                Role = user.Role.ToString(),
            };

        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = await _userRepo.GetAllUsers();

            return users.Select(user => new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role.ToString()
            }).ToList();
        }

        public async Task<UserEntity?> SignUp(LoginRequest request)
        {
            //Early exit if user is already registered
            var user = await _userRepo.GetUserAsync(request.UserName, request.Password);
            if (user is not null)
                return null;

            var newUser = new UserEntity
            {
                UserName = request.UserName,
                HashedPassword = request.Password, //TODO: Add AES encryption for securing password
                Role = Role.User, //TODO: Admin role can't be created with APIs 
            };

            return await _userRepo.AddUserAsync(newUser);
        }


    }
}
