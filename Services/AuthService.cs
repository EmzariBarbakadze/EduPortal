using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using EduPortal.Models.HelperClasses;

namespace EduPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _token;

        public AuthService(ApplicationDbContext context, ITokenService token)
        {
            _context = context;
            _token = token;
        }


        public Task<ServiceResponse<AuthResultDTO>> LoginAsync(UserLoginDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> LogoutAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AuthResultDTO>> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<AuthResultDTO>> RegisterAsync(UserRegisterDTO model)
        {
            var response = new ServiceResponse<AuthResultDTO>();

            if (model is null)
            {
                return response.FailResponse("Parameter for RegisterAsync can not be null");
            }

            return response.SuccessResponse(null, "Test");
        }

        public Task<Users?> ValidateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
