using EduPortal.Models.HelperClasses;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EduPortal.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponse<string>> RegisterAsync(UserRegisterDTO model);

        public Task<ServiceResponse<AuthResultDTO>> LoginAsync(UserLoginDTO model);

        public Task<ServiceResponse<AuthResultDTO>> RefreshTokenAsync(TokenRequestDTO model);

        public Task<ServiceResponse<bool>> LogoutAsync();

        public Task<ServiceResponse<AuthResultDTO>> VerifyEmail(string email, int code);

        public Task<ServiceResponse<string>> ForgotPasswordAsync(string email);
    }
}
