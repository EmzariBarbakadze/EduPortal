using EduPortal.Models.HelperClasses;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;

namespace EduPortal.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponse<string>> RegisterAsync(UserRegisterDTO model);

        public Task<ServiceResponse<AuthResultDTO>> LoginAsync(UserLoginDTO model);

        public Task<ServiceResponse<AuthResultDTO>> RefreshTokenAsync(string refreshToken);

        public Task<ServiceResponse<bool>> LogoutAsync(int userId);

        public Task<ServiceResponse<AuthResultDTO>> VerifyEmail(string email, int code);
    }
}
