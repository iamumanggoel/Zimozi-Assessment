namespace TaskManagerAPI.Models.DTOs
{
    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserResponse
    {
        public string Role { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int Id { get; set; }
    }

    public class LoginResponse: UserResponse
    {
        public string Token { get; set; } = string.Empty;
    }

}
