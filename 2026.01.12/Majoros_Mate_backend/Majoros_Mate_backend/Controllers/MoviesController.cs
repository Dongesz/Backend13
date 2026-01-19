using Majoros_Mate_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;

namespace Majoros_Mate_backend.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet("feladat10")]
        public IActionResult GetAllMovies()
        {
            using (var context = new CinemadbContext())
            {
                var movies = context.Movies.ToList();
                if (movies == null) return StatusCode(400, "Unable to connect to any of the specified mysql hosts.");
                return Ok(movies);
            }
        }

        [HttpPost("feladat13")]
        public IActionResult AddNewMovie(MoviePostDto movie, string uid)
        {
            using (var context = new CinemadbContext())
            {
                try
                {
                    if (Program.UID != uid) return StatusCode(401, "Nincs jogosultsag!");

                    var newMovie = new Movie()
                    {
                        Title = movie.Title,
                        ReleaseDate = movie.ReleaseDate,
                        ActorId = movie.ActorId,
                        FilmTypeId = movie.FilmTypeId
                    };
                    context.Movies.Add(newMovie);
                    context.SaveChanges();

                    return StatusCode(201, "Film hozzaadasa sikeres!");
                }
                catch (Exception ex)
                {

                    return NotFound();
                }
              
            }
        }
    }
}
