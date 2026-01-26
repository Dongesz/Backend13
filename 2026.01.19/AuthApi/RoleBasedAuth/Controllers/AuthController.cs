using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Models.DTOs;
using RoleBasedAuth.Services;

namespace RoleBasedAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth auth;

        public AuthController(IAuth auth)
        {
            this.auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var user = await auth.Register(dto);
            if (user != null)
            {
                return StatusCode(201, user);
            }
            return BadRequest();
        }
        [HttpPost("assignrole")]
        public async Task<IActionResult> AssignRole(AssignRoleDto dto)
        {
            var user = await auth.AssignRole(dto);
            if (user != null)
            {
                return StatusCode(201, user);
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await auth.Login(dto);
            if (user != null)
            {
                return StatusCode(201, user);
            }
            return BadRequest();
        }
    }
}
