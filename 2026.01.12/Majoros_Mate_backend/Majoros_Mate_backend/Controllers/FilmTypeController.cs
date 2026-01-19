using Majoros_Mate_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Majoros_Mate_backend.Controllers
{
    [Route("api/filmtypes")]
    [ApiController]
    public class FilmTypeController : ControllerBase
    {
        [HttpGet("feladat11")]
        public IActionResult GetAllFilmTypes()
        {
            using (var context = new CinemadbContext())
            {
                var types = context.FilmTypes.Include(x => x.Movies).ToList();
                if (types == null) return StatusCode(400, "Unable to connect to any of the specified mysql hosts.");

                return Ok(types);
            }
        }
    }
}
