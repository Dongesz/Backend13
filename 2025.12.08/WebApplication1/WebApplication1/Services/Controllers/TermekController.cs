using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Controllers
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

        [HttpGet("osszes-termek")]
        public async Task<ActionResult> GetAllRendeles()
        {
            var rendeles = await _service.GetAllTermek();
            if (rendeles == null) return NotFound();
            return Ok(rendeles);
        }

        [HttpGet("legnepszerubb-termek")]
        public async Task<ActionResult> GetLegnepszerubbTermek()
        {
            var rendeles = await _service.GetLegtobbTermekFogyott();
            if (rendeles == null) return NotFound();
            return Ok(rendeles);
        }

    }
}
