using Majoros_Mate_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Majoros_Mate_backend.Controllers
{
    [Route("api/actors/")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        [HttpGet("feladat9/{name}")]
        public IActionResult GetActors(string name)
        {
            using(var context = new CinemadbContext())
            {
                var actor = context.Actors.Include(x => x.Movies).FirstOrDefault(x => x.ActorName == name);
                if (actor == null) return NotFound();
                return Ok(actor);
            }
        }

        [HttpGet("feladat12")]
        public IActionResult GetActorsCount()
        {
            using( var context = new CinemadbContext())
            {
                var actorCount = context.Actors.ToList().Count();
                if (actorCount == null) return StatusCode(400, "Unable to connect to any of the specified mysql hosts.");

                return Ok($"Szineszek szama: {actorCount}");
            }
        }
    }
}
