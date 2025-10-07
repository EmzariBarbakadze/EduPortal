using EduPortal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
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
