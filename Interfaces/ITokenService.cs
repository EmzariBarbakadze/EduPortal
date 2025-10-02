using EduPortal.Models.Entities;

namespace EduPortal.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(Users user, List<string> roles);

        public UserTokens GenerateRefreshToken(int userId, string ipAdress, string deviceInfo, int? sessionId = null, int jwtId = 0);

        public string GenerateRandomSecureToken();
    }
}
