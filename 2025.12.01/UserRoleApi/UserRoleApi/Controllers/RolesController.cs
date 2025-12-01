using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Models.DTOs;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoles _service;

        public RolesController(IRoles service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewRole([FromBody] RolesSendDto dto)
        {
            if (dto == null) return BadRequest(new { message = "No payload" });

            var result = await _service.AddNewRole(dto);

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoles()
        {
            var result = await _service.GetAllRoles();

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);

            if (result == null)
                return NotFound(new { message = "Role not found" });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(Guid id, [FromBody] RolesUpdateDto dto)
        {
            if (dto == null) return BadRequest(new { message = "No payload" });

            var result = await _service.UpdateRole(id, dto);

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(Guid id)
        {
            var result = await _service.DeleteRole(id);

            if (result == null)
                return StatusCode(500, new { message = "Hiba a service-ben" });

            return Ok(result);
        }
    }
}
