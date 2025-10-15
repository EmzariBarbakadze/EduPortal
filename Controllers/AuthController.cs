using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;

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

            return Ok(response);
        }

        [HttpPost("ResendCode")]
        public async Task<IActionResult> ResendCode(string email)
        {
            return Ok();
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

            return Ok(response);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh()
        {
            return Ok();
        }
    }
}
