using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Services
{
    public class JwtTokenService(IConfiguration config) : IJwtTokenService
    {
        private readonly IConfiguration _config = config;

        /// <summary>
        /// Generates a new Jwt Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>newly generated jwt token</returns>
        public string GenerateToken(UserEntity user)
        {
            var expiry = DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_config["JwtSettings:DurationInMinutes"]));

            var token = new JwtSecurityToken(
                 issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role.ToString()) //Claim added for Authorization
                },
                expires: expiry,
                signingCredentials:
                    new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!)),
                        SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
