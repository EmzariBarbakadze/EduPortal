using Azure;
using EduPortal.Data;
using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using EduPortal.Models.HelperClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context
            , ITokenService token
            , IErrorLogger logger
            , IPasswordHasher<Users> hasher
            , IEmailService emailService
            , IHttpContextAccessor httpContextAccessor
            , IConfiguration config)
        {
            _context = context;
            _token = token;
            _logger = logger;
            _hasher = hasher;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
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

                var userRolesList = new List<string>();

                var authResult = new AuthResultDTO();

                foreach (var role in roles)
                {
                    userRolesList.Add(_context.Roles.FirstOrDefault(x => x.RoleId == role.RoleId)!.DescrEng);
                }

                authResult.AccessToken = _token.GenerateAccessToken(user, userRolesList);

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(authResult.AccessToken);

                var refreshTokenResponse = _token.GenerateRefreshToken(user.UserId, session.UserSessionId, jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value);
                authResult.RefreshToken = refreshTokenResponse.refreshToken;
                authResult.RefreshTokenExpireDate = refreshTokenResponse.expires;

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

            var userId = httpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
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

        public async Task<ServiceResponse<AuthResultDTO>> RefreshTokenAsync(string accessTokenInput, string refreshTokenRaw)
        {
            var response = new ServiceResponse<AuthResultDTO>();

            if(string.IsNullOrEmpty(accessTokenInput) || string.IsNullOrEmpty(refreshTokenRaw))
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "Invalid parameter for RefreshTokenAsync service",
                    "Service",
                    "RefreshTokenAsync",
                    null
                );

                return response.FailResponse("Invalid parameter for RefreshTokenAsync service");
            }

            var jwtSettings = _config.GetSection("JwtSettings");
            var principal = GetPrincipalFromTokenAsync(accessTokenInput, jwtSettings["Key"]!, false);

            if (principal is null || principal.Identity is null || !principal.Identity.IsAuthenticated)
            {
                await _logger.LogServiceErrorAsync(
                    "0000",
                    "Something went wrong in GetPrincipalFromTokenAsync, Invalid token is given",
                    "Service",
                    "RefreshTokenAsync",
                    null
                );

                return response.FailResponse("Something went wrong in GetPrincipalFromTokenAsync, Invalid token is given");
            }

            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                await _logger.LogServiceErrorAsync(
                    "0000",
                    "Token does not contain User id",
                    "Service",
                    "RefreshTokenAsync",
                    null
                );

                return response.FailResponse("Token does not contain User id");
            }

            var userId = int.Parse(userIdClaim);

            if (userId <= 0)
            {
                return response.FailResponse("Can not get user id from given access token");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user is null)
            {
                return response.FailResponse("User with given user id not found");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(accessTokenInput);
            var jwtId = jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;

            if (string.IsNullOrEmpty(jwtId))
            {
                return response.FailResponse("Invalid access token. Missing JTI");
            }

            var userRefreshToken = await _context.UserTokens
                .Where(x => x.JwtId == jwtId)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();

            if (userRefreshToken == null)
            {
                return response.FailResponse("Refresh token not found");
            }

            byte[] incomingTokenBytes = Convert.FromBase64String(refreshTokenRaw);

            using var hmac = new HMACSHA256(userRefreshToken.Salt);
            byte[] incomingHash = hmac.ComputeHash(incomingTokenBytes);

            bool isValidRefreshToken = CryptographicOperations.FixedTimeEquals(
                incomingHash,
                userRefreshToken.RefreshToken
            );

            if (!isValidRefreshToken)
            {
                return response.FailResponse("Given refresh token does not match user's refresh token");
            }

            if(userRefreshToken.ExpiresAt <= DateTime.Now)
            {
                return response.FailResponse("Session token is already revoked");
            }

            var userRoles = await _context.UsersRoles.Where(x => x.UserId == user.UserId).ToListAsync();
            var roles = new List<string>();

            foreach( var role in userRoles)
            {
                roles.Add(_context.Roles.FirstOrDefault(x => x.RoleId == role.RoleId)!.DescrEng);
            }

            try
            {
                var accessToken = _token.GenerateAccessToken(user, roles);
                var refreshToken = _token.GenerateRandomSecureToken();
                var newAccessToken = tokenHandler.ReadJwtToken(accessToken);
                var hashedRefreshToken = _token.HashRefreshToken(refreshToken);

                userRefreshToken.RefreshToken = hashedRefreshToken.hash;
                userRefreshToken.Salt = hashedRefreshToken.salt;
                userRefreshToken.JwtId = newAccessToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)!.ToString();
                userRefreshToken.CreatedAt = DateTime.Now;
                userRefreshToken.ExpiresAt = DateTime.Now.AddDays(Convert.ToDouble(_config["JwtSettings:RefreshTokenExpiresDays"]));
                userRefreshToken.RevokedAt = null;

                await _context.SaveChangesAsync();

                return response.SuccessResponse(new AuthResultDTO { AccessToken = accessToken, RefreshToken = refreshToken }, "Token refreshed successfully");
            }
            catch(Exception ex)
            {
                return response.FailResponse(ex.Message);
            }
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

                var userRolesList = new List<string>();

                foreach (var role in roles)
                {
                    userRolesList.Add(_context.Roles.FirstOrDefault(x => x.RoleId == role.RoleId)!.DescrEng);
                }

                var authResult = new AuthResultDTO();

                authResult.AccessToken = _token.GenerateAccessToken(user, userRolesList);

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(authResult.AccessToken);

                var refreshTokenResponse = _token.GenerateRefreshToken(user.UserId, session.UserSessionId, jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value);
                authResult.RefreshToken = refreshTokenResponse.refreshToken;
                authResult.RefreshTokenExpireDate = refreshTokenResponse.expires;

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

        public async Task<ServiceResponse<string>> ForgotPasswordAsync(string email)
        {
            var response = new ServiceResponse<string>();

            if (string.IsNullOrEmpty(email))
            {
                return response.FailResponse("Invalid parameter for ForgotPasswordAsync method - AuthService");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if(user is null)
            {
                return response.FailResponse("Given email not found in database");
            }

            if(user.StatusId != 1)
            {
                return response.FailResponse("Can not change password of the user who is not active");
            }

            var emailVerificator = new EmailVerification
            {
                UserId = user.UserId,
                Email = user.Email,
                Code = new Random().Next(10000, 99999), 
                Created = DateTime.Now, 
                ExpirationDate = DateTime.Now.AddMinutes(1), 
                IsUsed = false
            };

            try
            {
                await _context.EmailVerification.AddAsync(emailVerificator);
                await _context.SaveChangesAsync();               
            }
            catch(Exception ex)
            {
                return response.FailResponse(ex.Message);
            }

            var subject = "Password reset Pin code - Don't replay";
            var body = $@"<html>
                          <body style='font-family: Arial, sans-serif; color: #333;'>
                            <h2>Password reset pin code <span style='color:#0078D4;'> -  EduPortal</span>!</h2>
                            <h4>{emailVerificator.Code}</h4>
                            <p>The code is valid untill {emailVerificator.ExpirationDate}</p>
                            <br />
                            <hr />
                            <br />
                            <p style='font-size:12px; color:#999;'>This is an automated message. Please do not reply.</p>
                          </body>
                        </html>";

            var notification = new Notifications
            {
                UserId = user.UserId,
                NotificationTypeId = 8,
                Message = body,
                Created = DateTime.Now,
                IsSent = false
            };

            try
            {
                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();

                await _emailService.SendEmailAsync(email, subject, body);
            }
            catch(Exception ex)
            {
                await _logger.LogServiceErrorAsync(
                   "0000",
                   ex.Message,
                   "Service",
                   "ForgotPasswordAsync",
                   null
                   );
                return response.FailResponse($"Unknown error in ForgotPasswordAsync (auth service) {ex.Message}");
            }

            notification.IsSent = true;
            await _context.SaveChangesAsync();

            return response.SuccessResponse(email, $"Password reset pin code successfully sent on {email}");
        }

        public async Task<ServiceResponse<bool>> ResetPasswordAsync(ResetPasswordDTO model)
        {
            var response = new ServiceResponse<bool>();

            if (model is null)
            {
                return response.FailResponse("Parameter for ResetPasswordAsync service can not be null or empty");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user is null)
            {
                return response.FailResponse("User with given email not found - ResetPasswordAsync");
            }

            var verificator = await _context.EmailVerification.Where(x => x.Email == model.Email).OrderByDescending(x => x.Created).FirstOrDefaultAsync();

            if(verificator is null)
                return response.FailResponse("Can not find proper email verificator in db - ResetPasswordAsync");

            if (verificator.Code != model.PinCode)
                return response.FailResponse("Incorrect pin code is given");

            if (verificator.ExpirationDate < DateTime.Now)
                return response.FailResponse("Pin code is expired");

            if (verificator.IsUsed == true)
                return response.FailResponse("This pin code is already used so it is not valid anymore");

            if (model.Password != model.RepeatPassword)
                return response.FailResponse("Given passwords do not match each other");

            var passwordHash = _hasher.HashPassword(user, model.Password);

            try
            {
                user.PasswordHash = passwordHash;
                await _context.SaveChangesAsync();

                return response.SuccessResponse(true, "Password changed successfully");
            }
            catch(Exception ex)
            {
                return response.FailResponse(ex.Message);
            }
        }

        public async Task<ServiceResponse<PersonalInfoDTO>> MeAsync()
        {
            var response = new ServiceResponse<PersonalInfoDTO>();
            var httpContext = _httpContextAccessor.HttpContext;

            if(httpContext is null)
                return response.FailResponse("Http context can not be null in MeAsync service");

            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId is null)
                return response.FailResponse("Can not take user id from http context");

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId.ToString() == userId);

            if (user is null)
                return response.FailResponse("Can not find user with given id in database");

            try
            {
                var userInfo = new PersonalInfoDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };

                var userRoles = await _context.UsersRoles.Where(x => x.UserId == user.UserId).ToListAsync();

                var roles = new List<string>();

                foreach (var role in userRoles)
                {
                    var roleObject = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == role.RoleId);
                    roles.Add(roleObject!.DescrEng);
                }

                userInfo.Roles = roles;

                return response.SuccessResponse(userInfo, "User information found successfully");
            }
            catch(Exception ex)
            {
                return response.FailResponse(ex.Message);
            }
        }

        private ClaimsPrincipal? GetPrincipalFromTokenAsync(string token, string secret, bool validateLifetime)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = validateLifetime,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                if (validatedToken is JwtSecurityToken jwtToken &&
                   jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return principal;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
