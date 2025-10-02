using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduPortal.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public TokenService(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        public string GenerateAccessToken(Users user, List<string> roles)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var expireMinutes = double.Parse(jwtSettings["AccessTokenExpiresMinutes"]!);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  // Globally unique identifier - 128 bit value
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRandomSecureToken()
        {
            var randomBytes = new byte[64];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }

        public UserTokens GenerateRefreshToken(int userId, string ipAdress, string deviceInfo, int? sessionId = null, int jwtId = 0)
        {
            var config = _config.GetSection("JwtSettings");

            var userToken = new UserTokens
            {
                UserId = userId,
                RefreshToken = GenerateRandomSecureToken(),
                IpAdress = ipAdress,
                JwtId = jwtId,
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(double.Parse(config["RefreshTokenExpiresDays"]!)),
                DeviceInfo = deviceInfo, 
                SessionId = sessionId
            };

            _context.UserTokens.Add(userToken);
            _context.SaveChanges();

            return userToken;
        }
    }
}
