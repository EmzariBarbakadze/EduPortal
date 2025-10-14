using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using EduPortal.Models.HelperClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _token;
        private readonly IErrorLogger _logger;
        private readonly IPasswordHasher<Users> _hasher;

        public AuthService(ApplicationDbContext context, ITokenService token, IErrorLogger logger, IPasswordHasher<Users> hasher)
        {
            _context = context;
            _token = token;
            _logger = logger;
            _hasher = hasher;
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

        public async Task<ServiceResponse<string>> RegisterAsync(UserRegisterDTO model)
        {
            var response = new ServiceResponse<string>();

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

            if (await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.IsVerified == true) is not null)
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

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.IsVerified == false);
            var newUser = new Users();

            if(user is not null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.Email.Split('@')[0];
                user.PasswordHash = _hasher.HashPassword(user, model.Password);
                user.StatusId = 5;
            }
            else
            {
                newUser = new Users
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email.Split('@')[0],
                    StatusId = 5
                };

                newUser.PasswordHash = _hasher.HashPassword(newUser, model.Password);

                await _context.Users.AddAsync(newUser);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    return response.FailResponse(ex.Message);
                }
            }
                      

            var emailVerificator = new EmailVerification 
            { 
                UserId = user?.UserId ?? newUser.UserId,
                Email = model.Email,
                Code = new Random().Next(10000, 99999)
            };

            try
            {
                await _context.EmailVerification.AddAsync(emailVerificator);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return response.FailResponse("Failed to save in DB. AuthService - Register");
            }
            return response.SuccessResponse(model.Email, $"Code sent to the email {model.Email}");
        }

        public Task<Users?> ValidateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
