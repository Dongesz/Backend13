using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Models.DTOs;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _service;

        public UserController(IUser services)
        {
            _service = services;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUser([FromBody] UserSendDto dto)
        {
            if (dto == null) return BadRequest(new { message = "No payload" });

            var result = await _service.AddNewUser(dto);

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var result = await _service.GetAllUser();

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);

            if (result == null)
                return NotFound(new { message = "User not found" });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UserUpdateDto dto)
        {
            if (dto == null) return BadRequest(new { message = "No payload" });

            var result = await _service.UpdateUser(id, dto);

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var result = await _service.DeleteUser(id);

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }
    }
}
