using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

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
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
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

        public byte[] GenerateRandomSecureToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);

            return randomBytes;
        }

        public (byte[] hash, byte[] salt) HashRefreshToken(byte[] token)
        {
            var salt = RandomNumberGenerator.GetBytes(32);
            using var hmac = new HMACSHA256(salt);
            var hashed = hmac.ComputeHash(Encoding.UTF8.GetBytes(token.ToString()!));

            return (hashed, salt);
        }

        public (byte[], DateTime) GenerateRefreshToken(int userId, int? sessionId = null, string? jwtId = null)
        {
            var config = _config.GetSection("JwtSettings");
            var refreshToken = GenerateRandomSecureToken();
            var hashedRefreshToken = HashRefreshToken(refreshToken);

            var userToken = new UserTokens
            {
                UserId = userId,
<<<<<<< HEAD
                RefreshToken = HashRefreshToken(refreshToken).hash,
                JwtId = jwtId!,
=======
                RefreshToken = hashedRefreshToken.hash,
                Salt = hashedRefreshToken.salt,
                JwtId = jwtId,
>>>>>>> 81136f55bb98b6c96e3dc866f32de7886a9f4753
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(double.Parse(config["RefreshTokenExpiresDays"]!)),
                SessionId = sessionId
            };

            _context.UserTokens.Add(userToken);
            _context.SaveChanges();

            return (refreshToken, userToken.ExpiresAt);
        }
    }
}
