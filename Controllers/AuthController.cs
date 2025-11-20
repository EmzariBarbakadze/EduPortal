using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EduPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IErrorLogger _logger;

        public AuthController(IAuthService authService, IErrorLogger logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "Modelstate is not valid in Register controller",
                    "Controller",
                    "Register",
                    null
                );
                return BadRequest(ModelState);
            }

            var response = await _authService.RegisterAsync(dto);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string email, int code)
        {
            if (!ModelState.IsValid)
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "Modelstate is not valid in Register controller",
                    "Controller",
                    "Register",
                    null
                );
                return BadRequest(ModelState);
            }

            var response = await _authService.VerifyEmail(email, code);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            Response.Cookies.Append(
                    "refreshToken",
                    response.Data!.RefreshToken.ToString(),
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = response.Data.RefreshTokenExpireDate
                    }
                );

            return Ok(response.Data!.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "Modelstate is not valid in Login controller",
                    "Controller",
                    "Login",
                    null
                );
                return BadRequest(ModelState);
            }

            var response = await _authService.LoginAsync(dto);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            Response.Cookies.Append(
                   "refreshToken",
                   response.Data!.RefreshToken.ToString(),
                   new CookieOptions
                   {
                       HttpOnly = true,
                       Secure = true,
                       SameSite = SameSiteMode.Strict,
                       Expires = response.Data.RefreshTokenExpireDate
                   }
               );

            return Ok(response.Data!.AccessToken);
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(TokenRequestDTO dto)
        {
            if (!ModelState.IsValid)
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "Modelstate is not valid in Refresh controller",
                    "Controller",
                    "Refresh",
                    null
                );
                return BadRequest(ModelState);
            }

            var response = await _authService.RefreshTokenAsync(dto);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email) || !ModelState.IsValid)
            {
                await _logger.LogServiceErrorAsync(
                   "1000",
                   "Invalid parameter for ForgotPassword controller",
                   "Controller",
                   "ForgotPassword",
                   null
                );
                return BadRequest(ModelState);
            }

            var response = await _authService.ForgotPasswordAsync(email);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPost("ResetPassword")]  
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            if(!ModelState.IsValid || dto is null)
            {
                await _logger.LogServiceErrorAsync(
                   "1000",
                   "Invalid parameter for ResetPassword controller",
                   "Controller",
                   "ResetPassword",
                   null
                );
                return BadRequest(ModelState);
            }

            var response = await _authService.ResetPasswordAsync(dto);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }



        // Authorized endpoints 
        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var response = await _authService.LogoutAsync();

            if (!response.Success)
            {
                await _logger.LogServiceErrorAsync(
                  "0000",
                  "Error from logout service",
                  "Controller",
                  "Logout",
                  null
                );
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet("Me")]  // Needs parameters define the flow first
        public async Task<IActionResult> Me()
        {
            var response = await _authService.MeAsync();

            if (!response.Success)
            {
                await _logger.LogServiceErrorAsync(
                  "0000",
                  "Error from Me service",
                  "Controller",
                  "Me",
                  null
                );
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
    }
}