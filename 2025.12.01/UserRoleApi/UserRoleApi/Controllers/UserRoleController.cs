using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Models.DTOs;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoles _service;

        public UserRolesController(IUserRoles service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUserRole(UserRoleSendDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "No payload" });

            var result = await _service.AddNewUserRole(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUserRoles()
        {
            var result = await _service.GetAllUserRoles();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserRole(Guid id, UserRolesUpdateDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "No payload" });

            var result = await _service.UpdateUserRole(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserRole(Guid id)
        {
            var result = await _service.DeleteUserRole(id);
            return Ok(result);
        }
    }
}
