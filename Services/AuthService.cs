using Azure;
using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using EduPortal.Models.HelperClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;

namespace EduPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _token;
        private readonly IErrorLogger _logger;
        private readonly IPasswordHasher<Users> _hasher;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(ApplicationDbContext context, ITokenService token, IErrorLogger logger, IPasswordHasher<Users> hasher, IEmailService emailService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _token = token;
            _logger = logger;
            _hasher = hasher;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<AuthResultDTO>> LoginAsync(UserLoginDTO model)
        {
            var response = new ServiceResponse<AuthResultDTO>();

            if(model is null)
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "Parameter for LoginAsync can not be null",
                    "Service",
                    "LoginAsync",
                    null
                    );

                return response.FailResponse("Parameter for LoginAsync can not be null");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName);

            if(user is null)
            {
                return response.FailResponse("User with given username can not be found");
            }

            if(user.LastLoginAttempt?.AddHours(5) <= DateTime.Now)
            {
                user.LoginFailCounter = 0;
                user.IsLocked = false;
                user.LockedUntill = null;

                await _context.SaveChangesAsync();
            }

            if(user.IsLocked && user.LockedUntill >= DateTime.Now)
            {
                return response.FailResponse($"The user account is locked untill {user.LockedUntill}");
            }

            if(user.LockedUntill < DateTime.Now && user.IsLocked)
            {
                user.LoginFailCounter = 0;
                user.IsLocked = false;
                user.LockedUntill = null;

                await _context.SaveChangesAsync();
            }

            user.LastLoginAttempt = DateTime.Now;

            var verifyResult = _hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (verifyResult == PasswordVerificationResult.Failed)
            {
                user.LoginFailCounter++;
                
                if(user.LoginFailCounter >= 5)
                {
                    user.IsLocked = true;
                    user.LockedUntill = DateTime.Now.AddMinutes(5);

                    var subject = "Your EduPortal Account Has Been Locked";
                    var body = $@"<html>
                                  <body style='font-family: Arial, sans-serif; color: #333;'>
                                    <h2 style='color:#0078D4;'>Account Locked for Security Reasons</h2>
                                    <p>Dear {user.FirstName},</p>
                                    <p>Your EduPortal account has been temporarily locked after multiple failed login attempts.</p>
                                    <p>Locked untill {user.LockedUntill}</p>
                                    <p>If you didn’t try to sign in, you can ignore this email.</p>
                                    <hr style='border:none; border-top:1px solid #ccc;' />
                                    <p style='font-size:12px; color:#777;'>This is an automated message. Please do not reply.</p>
                                  </body>
                                </html>";

                    var notification = new Notifications
                    {
                        UserId = user.UserId,
                        NotificationTypeId = 9,
                        Message = body,
                        Created = DateTime.Now,
                        IsSent = false
                    };

                    try
                    {
                        await _context.Notifications.AddAsync(notification);
                        await _context.SaveChangesAsync();
                        await _emailService.SendEmailAsync(user.Email, subject, body);                        
                    }
                    catch(Exception ex)
                    {
                        await _logger.LogServiceErrorAsync(
                        "1000",
                        $"Email could not be sent to {user.Email}",
                        "Service",
                        "LoginAsync",
                        null
                        );

                        return response.FailResponse(ex.Message);
                    }

                    notification.IsSent = true;
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync(); 
                return response.FailResponse(user.LoginFailCounter == 5 ? $"Your account got locked untill {user.LockedUntill}" : "Incorrect Password");
            }

            try
            {
                // Register the session

                var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var deviceInfo = _httpContextAccessor.HttpContext?.Request?.Headers["User-Agent"].ToString();

                var session = new UsersSessions
                {
                    UserId = user.UserId,
                    DateStart = DateTime.Now,
                    IpAdress = ipAddress,
                    RestrictionLevelId = 1,
                    DeviceInfo = deviceInfo
                };

                user.LoginFailCounter = 0;

                await _context.UsersSessions.AddAsync(session);
                await _context.SaveChangesAsync();

                // Create Access and Refresh tokens

                var roles = await _context.UsersRoles.Where(x => x.UserId == user.UserId).ToListAsync();

                var userRolesList = new List<int>();

                foreach (var role in roles)
                {
                    userRolesList.Add(role.RoleId);
                }

                var authResult = new AuthResultDTO();

                authResult.AccessToken = _token.GenerateAccessToken(user, userRolesList);

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(authResult.AccessToken);

                authResult.RefreshToken = _token.GenerateRefreshToken(user.UserId, session.UserSessionId, jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value);

                await _context.SaveChangesAsync();
                return response.SuccessResponse(authResult, $"User {user.UserName} logged in successfully");
            }
            catch (Exception ex)
            {
                await _logger.LogServiceErrorAsync(
                  "0000",
                  ex.Message,
                  "Service",
                  "VerifyEmail",
                  null
                );
                return response.FailResponse(ex.Message);
            }
        }

        public async Task<ServiceResponse<bool>> LogoutAsync()
        {
            var response = new ServiceResponse<bool>();
            var httpContext = _httpContextAccessor.HttpContext;

            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var jwtId = httpContext.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;

            if (userId is null || jwtId is null)
                return response.FailResponse("Invalid jwt token. Can not logout!");

            var storedToken = await _context.UserTokens.FirstOrDefaultAsync(x => x.JwtId == jwtId);
            if (storedToken is null)
                return response.FailResponse("Can not find userToken with given jwt id");

            var userSession = await _context.UsersSessions.FirstOrDefaultAsync(x => x.UserSessionId == storedToken.SessionId);
            if (userSession is null)
                return response.FailResponse("Can not find user session with given session id");
            else if (userSession.DateEnd is not null || userSession.DateEnd < DateTime.Now)
                return response.FailResponse("Session is already finished or something went wrong. check logout service");

            try
            {
                storedToken.RevokedAt = DateTime.Now;
                userSession.DateEnd = DateTime.Now;

                await _context.SaveChangesAsync();

                return response.SuccessResponse(true, "User logged out successfully");
            }
            catch(Exception ex)
            {
                return response.FailResponse($"Unknown error in logout service: {ex.Message}");
            }
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
                    "1012",
                    "User already registered",
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

            var code = new Random().Next(10000, 99999);

            var emailVerificator = new EmailVerification
            {
                UserId = user?.UserId ?? newUser.UserId,
                Email = model.Email,
                Code = code
            };

            if (await _context.UsersRoles.FirstOrDefaultAsync(x => x.UserId == emailVerificator.UserId) is null)
            {
                var userRole = new UsersRoles
                {
                    UserId = emailVerificator.UserId,
                    RoleId = 1
                };

                await _context.UsersRoles.AddAsync(userRole);
            }

            try
            {
                await _context.EmailVerification.AddAsync(emailVerificator);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return response.FailResponse(ex.Message);
            }

            var subject = "Email verification on EduPortal";
            var body = $@"<html>
                          <body style='font-family: Arial, sans-serif; color: #333;'>
                            <h2>Verification Code <span style='color:#0078D4;'> -  EduPortal</span>!</h2>
                            <h4>{code}</h4>
                            <p>The code is valid untill {emailVerificator.ExpirationDate}</p>
                            <br />
                            <hr />
                            <br />
                            <p style='font-size:12px; color:#999;'>This is an automated message. Please do not reply.</p>
                          </body>
                        </html>";

            var notification = new Notifications 
            { 
                UserId = emailVerificator.UserId,
                NotificationTypeId = 8,
                Message = body,
                Created = emailVerificator.Created
            };            

            try
            {
                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();
                await _emailService.SendEmailAsync(model.Email, subject, body);
            }
            catch(Exception ex)
            {
                return response.FailResponse(ex.Message);
            }

            notification.IsSent = true;
            _context.Update(notification);
            await _context.SaveChangesAsync();

            return response.SuccessResponse(model.Email, $"Code sent to the email {model.Email}");
        }

        public async Task<ServiceResponse<AuthResultDTO>> VerifyEmail(string email, int code)
        {
            var response = new ServiceResponse<AuthResultDTO>();

            if (email is null)
            {
                await _logger.LogServiceErrorAsync(
                        "1000",
                        "Parameter for RegisterAsync can not be null",
                        "Service",
                        "VerifyEmail",
                        null
                );
                return response.FailResponse("Parameter for VerifyEmail can not be null");
            }

            var emailVerificator = await _context.EmailVerification.OrderByDescending(x => x.Created).FirstOrDefaultAsync(x => x.Email == email);

            if(emailVerificator is null || emailVerificator.IsUsed)
            {
                await _logger.LogServiceErrorAsync(
                       "0000",
                       "Can not find email verificator or it is already used",
                       "Service",
                       "VerifyEmail",
                       null
                );
                return response.FailResponse("Can not find email verificator or it is already used");
            }

            if(emailVerificator.Code != code)
            {
                return response.FailResponse("Inputed pin code is not correct");
            }
            else if(emailVerificator.Code == code && emailVerificator.ExpirationDate < DateTime.Now)
            {
                return response.FailResponse("Inputed pin code is expired");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == emailVerificator.UserId);
            
            if(user is null)
            {
                await _logger.LogServiceErrorAsync(
                      "1001",
                      $"User with this id can not be found - {emailVerificator.UserId}",
                      "Service",
                      "VerifyEmail",
                      null
                );
                return response.FailResponse("Internal error. Check error logs - service: VerifyEmail");
            }

            user.IsVerified = true;
            user.StatusId = 1;
            emailVerificator.IsUsed = true;

            try
            {
                // Register the session

                var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var deviceInfo = _httpContextAccessor.HttpContext?.Request?.Headers["User-Agent"].ToString();

                var session = new UsersSessions
                {
                    UserId = user.UserId,
                    DateStart = DateTime.Now,
                    IpAdress = ipAddress,
                    RestrictionLevelId = 1, 
                    DeviceInfo = deviceInfo
                };

                await _context.UsersSessions.AddAsync(session);
                await _context.SaveChangesAsync();

                // Create Access and Refresh tokens

                var roles = await _context.UsersRoles.Where(x => x.UserId == user.UserId).ToListAsync();

                var userRolesList = new List<int>();

                foreach (var role in roles)
                {
                    userRolesList.Add(role.RoleId);
                }

                var authResult = new AuthResultDTO();

                authResult.AccessToken = _token.GenerateAccessToken(user, userRolesList);

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(authResult.AccessToken);

                authResult.RefreshToken = _token.GenerateRefreshToken(user.UserId, session.UserSessionId, jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value);

                await _context.SaveChangesAsync();
                return response.SuccessResponse(authResult, $"Email {emailVerificator.Email} verified successfully.");
            }
            catch(Exception ex)
            {
                await _logger.LogServiceErrorAsync(
                      "0000",
                      ex.Message,
                      "Service",
                      "VerifyEmail",
                      null
                );
                return response.FailResponse(ex.Message);
            }
        }
    }
}