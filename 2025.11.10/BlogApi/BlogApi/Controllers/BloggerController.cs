using BlogApi.Model;
using BlogApi.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddBlogger(AddBloggerDto blogger)
        {
            try
            {
                var newBlogger = new Blogger()
                {
                    Name = blogger.Name,
                    Password = blogger.Password,
                    Email = blogger.Email,
                    Phone = blogger.Phone
                };

                using (var context = new BlogDbContext())
                {
                    if (newBlogger != null)
                    {
                        context.bloggers.Add(newBlogger);
                        context.SaveChanges();
                        return StatusCode(201, newBlogger);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                using (var context = new BlogDbContext())
                {

                    return Ok(context.bloggers.ToList());

                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var blog = context.bloggers.SingleOrDefault(b => b.Id == id);
                    return Ok(blog);
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var blog = context.bloggers.SingleOrDefault(b => b.Id == id);
                    context.bloggers.Remove(blog);
                    context.SaveChanges();
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(int id, UpdateBloggerDto dto)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var blog = context.bloggers.SingleOrDefault(b => b.Id == id);
                    blog.Name = dto.Name;
                    blog.Email = dto.Email;
                    blog.Password = dto.Password;
                    blog.Phone = dto.Phone;
                    blog.ModTime = DateTime.Now;
                    context.Update(blog);
                    context.SaveChanges();
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
