using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        private readonly ITermekek _service;

        public TermekController(ITermekek service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRendeles()
        {
            var rendeles = await _service.GetAllTermek();
            if (rendeles == null) return NotFound();
            return Ok(rendeles);
        }

    }
}
