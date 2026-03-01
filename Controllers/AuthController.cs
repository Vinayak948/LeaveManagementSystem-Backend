using LeaveManagementSystem_Backend.DTO;
using LeaveManagementSystem_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
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

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var result = _authService.Register(dto);
            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var result = _authService.Login(dto);
            return Ok(result);
        }
    }
}