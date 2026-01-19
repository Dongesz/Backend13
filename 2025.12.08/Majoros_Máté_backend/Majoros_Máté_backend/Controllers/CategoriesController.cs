using Majoros_Máté_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Majoros_Máté_backend.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("feladat11")]
        public IActionResult feladat11()
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    var categories = context.Categories.Include(x => x.Books).ToList();
                    if (categories == null) NotFound();
                    return Ok(categories);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, "Unable to connect to any of the specified MySQL hosts.");
                }
            }
        }
    }
}
