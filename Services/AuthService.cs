using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using EduPortal.Models.HelperClasses;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _token;
        private readonly IErrorLogger _logger;

        public AuthService(ApplicationDbContext context, ITokenService token, IErrorLogger logger)
        {
            _context = context;
            _token = token;
            _logger = logger;
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
                await _logger.LogServiceErrorAsync(
                    "1000", 
                    "Parameter for RegisterAsync can not be null",
                    "Service",
                    "RegisterAsync", 
                    null
                    );
                return response.FailResponse("Parameter for RegisterAsync can not be null");
            }

            if (await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.StatusId != 6) is not null)
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "User with this email already exists",
                    "Service",
                    "RegisterAsync",
                    null
                    );
                return response.FailResponse("User with this email already exists");
            }

            if(await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.StatusId == 6) is not null)
            {
                return response; // ჯერ გამართე მესიჯების გამგზავნი ჯობი. რეგისტრაციისას გაითვალისწინე როლები. ლექტორის როლის ამბავს ადასტურებს ადმინი
            }

            return response.SuccessResponse(null, "Test");
        }

        public Task<Users?> ValidateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
