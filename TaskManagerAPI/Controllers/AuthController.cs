using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [AllowAnonymous, HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.Login(request);

            if(result is null)
                return Unauthorized("Invalid credentials");

            return Ok(result);
        }

        [AllowAnonymous, HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody] LoginRequest request)
        {
            var user = await _authService.SignUp(request);
            if(user is null)
                return Conflict(new { Message = $"User with {request.UserName} already exists. Please log in." });

            return Ok(user);
        }

        [Authorize(Roles = "Admin"), HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _authService.GetAllUsers();

            if (users is null || users.Count == 0)
                return NotFound(new { Message = $"No Such for this context available." });

            return Ok(users);
        }

        


    }
}
