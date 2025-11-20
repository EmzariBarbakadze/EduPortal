using EduPortal.Models.Entities;

namespace EduPortal.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(Users user, List<string> roles);

        public (byte[] refreshToken, DateTime expires) GenerateRefreshToken(int userId, int? sessionId = null, string? jwtId = null);

        public byte[] GenerateRandomSecureToken();
    }
}
