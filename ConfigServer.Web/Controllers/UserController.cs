using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigServer.Domain.Interfaces;
using ConfigServer.Application.DTOs;
using ConfigServer.Infrasrtacture.Services;

namespace ConfigServer.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var token = await _userService.RegisterAsync(registerDto.Email, registerDto.Password);
            return Ok(new AuthResponseDto { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto.Email, loginDto.Password);
            return Ok(new AuthResponseDto { Token = token });
        }
    }
}
