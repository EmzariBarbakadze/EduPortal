using EduPortal.Models.Entities;

namespace EduPortal.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(Users user, List<int> roles);

        public string GenerateRefreshToken(int userId, int? sessionId = null, string? jwtId = null);

        public string GenerateRandomSecureToken();
    }
}
