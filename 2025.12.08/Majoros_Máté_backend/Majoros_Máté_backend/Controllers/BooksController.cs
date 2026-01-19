using Majoros_Máté_backend.Models;
using Majoros_Máté_backend.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Majoros_Máté_backend.Controllers
{
    [Route("api/books/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("feladat10")]
        public IActionResult feladat10()
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    var result = context.Books.ToList();
                    if (result == null) return NotFound();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, "Unable to connect to any of the specified MySQL hosts.");
                }
            }
        }
        [HttpPut("feladat13/{UId}")]
        public IActionResult feladat13(string UId, BookSendDto book)
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    if (Program.UID != UId) return StatusCode(401, "Nincs jogosultsag a konyv feltoltesehez!");
                    var result = new Book
                    {
                        Title = book.Title,
                        PublishDate = DateTime.Now,
                        AuthorId = book.AuthorId,
                        CategoryId = book.CategoryId,
                    };
                    context.Books.Add(result);
                    context.SaveChanges();
                    return StatusCode(201, "konyv hozzaadasa megtortent!");

                    
                }
                catch (Exception ex)
                {
                    return StatusCode(400, "Unable to connect to any of the specified MySQL hosts.");
                }
            }
        }
    }
}