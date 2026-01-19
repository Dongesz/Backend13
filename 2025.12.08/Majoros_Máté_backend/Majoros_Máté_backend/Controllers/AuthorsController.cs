using Majoros_Máté_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Majoros_Máté_backend.Controllers
{
    [Route("api/authors/")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet("feladat9/{author}")]
        public IActionResult feladat9(string author)
        {
            using(var context = new LibrarydbContext())
            {
                try
                {
                    var user = context.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorName == author);

                    if (user == null) return NotFound();

                   
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, "Unable to connect to any of the specified MySQL hosts.");
                }
            }
        }
        [HttpGet("feladat12")]
        public IActionResult feladat12()
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    var user = context.Authors.ToList();

                    if (user == null) return NotFound();


                    return Ok("Szerzők száma: " + user.Count);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, "Nem lehet csatlakozni az adatbazishoz.");
                }
            }
        }
    }
}
