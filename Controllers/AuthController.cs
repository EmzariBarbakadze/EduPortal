using EduPortal.Interfaces;
using EduPortal.Models.Entities;
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

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            try
            {
                return Ok();
            }
            catch (ValidationException ex)
            {
                // await _logger.LogExceptionAsync(ex, HttpContext, null);
                return BadRequest("Invalid input.");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Refresh()
        {
            return Ok();
        }

        public async Task<IActionResult> Me()
        {
            return Ok();
        }
    }
}
