using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RendszerKez.Dtos;
using RendszerKez.Services.Interfaces;

namespace RendszerKez.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _service.LoginAsync(dto);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _service.RegisterAsync(dto);

            if (!result)
                return BadRequest("Email already exists");

            return Ok("User registered successfully");
        }
    }
}
