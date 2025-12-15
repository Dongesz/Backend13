using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Controllers
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
        [HttpGet("kartyaval")]
        public async Task<ActionResult> GetAllRendelesWithCard()
        {
            var rendeles = await _service.GetAllRendelesWithCard();
            if (rendeles == null) return NotFound();
            return Ok(rendeles);
        }
        [HttpGet("kajaval")]
        public async Task<ActionResult> GetAllRendelesWithFood()
        {
            var response = await _service.GetAllRendelesWithFood();
            if (response != null)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
  
        [HttpGet("tetelek")]
        public async Task<ActionResult> GetRendelesenkentTetelek()
        {
            var response = await _service.GetRendelesenkentTetelek();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("termek-rendeles")]
        public async Task<ActionResult> GetTermekekRendelesenkent()
        {
            var response = await _service.GetTermekekRendelesenkent();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("kola")]
        public async Task<ActionResult> GetKolasRendelesek()
        {
            var response = await _service.GetKolasRendelesek();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("tetelszam")]
        public async Task<ActionResult> GetRendelesekTetelszama()
        {
            var response = await _service.GetRendelesekTetelszama();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("kettes-osszertek")]
        public async Task<ActionResult> GetKettesRendelesOsszertek()
        {
            var response = await _service.GetKettesRendelesOsszertek();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("rendelesek-osszertek")]
        public async Task<ActionResult> GetRendelesekOsszerteke()
        {
            var response = await _service.GetRendelesekOsszerteke();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("legdragabb-rendeles")]
        public async Task<ActionResult> GetLegdragabbRendeles()
        {
            var response = await _service.GetLegdragabbRendeles();
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("rendelesek-szama-asztalonkent")]
        public async Task<ActionResult> GetAsztalokHanyszorRendeltek()
        {
            var response = await _service.GetAsztalokHanyszorRendeltek();
            if (response == null) return NotFound();
            return Ok(response);
        }
        [HttpGet("fizetesimod-hanyszor")]
        public async Task<ActionResult> GetFizetesModHanyszor()
        {
            var response = await _service.GetFizetesModHanyszor();
            if (response == null) return NotFound();
            return Ok(response);
        }
        [HttpGet("asztal-legtobb-koltessel")]
        public async Task<ActionResult> GetAsztalLegtobbKoltessel()
        {
            var response = await _service.GetAsztalLegtobbKoltessel();
            if (response == null) return NotFound();
            return Ok(response);
        }

    }
}
