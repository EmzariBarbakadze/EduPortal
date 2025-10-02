using EduPortal.Models.Entities;

namespace EduPortal.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(Users user);
    }
}
