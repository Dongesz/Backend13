using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesController : ControllerBase
    {
        private readonly IRendeles _service;

        public RendelesController(IRendeles service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRendeles()
        {
            var rendeles = await _service.GetAllRendeles();
            if (rendeles == null) return NotFound();
            return Ok(rendeles);
        }
        [HttpGet("withCard")]
        public async Task<ActionResult> GetAllRendelesWithCard()
        {
            var rendeles = await _service.GetAllRendelesWithCard();
            if (rendeles == null) return NotFound();
            return Ok(rendeles);
        }
        [HttpGet("withfood")]
        public async Task<ActionResult> GetAllRendelesWithFood()
        {
            var response = await _service.GetAllRendelesWithFood();
            if (response != null)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


    }
}
