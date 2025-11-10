using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using olimpikonokAPI.Models;

namespace olimpikonokAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrszagController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    var orszagok = context.Orszags.ToList();
                    return Ok(orszagok);
                }
                catch (Exception x)
                {

                    List<Orszag> orszagok = new List<Orszag>();
                    Orszag hiba = new Orszag()
                    {
                        Id = -1,
                        Nev = $"Hiba az adatok betoltese kozben: {x.Message}"
                    };
                    orszagok.Add(hiba);
                    return BadRequest(orszagok);
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    var orszagok = context.Orszags.FirstOrDefault(x => x.Id == id);
                    if (orszagok != null)
                    {
                        return Ok(orszagok);
                    }
                    else return NotFound(new Orszag() { Id = id});
                }
                catch (Exception x)
                {

                    Orszag hiba = new Orszag()
                    {
                        Id = -1,
                        Nev = $"Hiba az adatok betoltese kozben: {x.Message}"
                    };
                    return BadRequest(hiba);
                }
            }
        }
    }
}
