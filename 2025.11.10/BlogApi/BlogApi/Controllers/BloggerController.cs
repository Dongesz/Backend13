using BlogApi.Model;
using BlogApi.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("withPosts")]
        public IActionResult GetBloggerWithPosts()
        {
            try
            {
                using(var context = new BlogDbContext())
                {
                    var bloggerWithPosts = context.bloggers.Include(b => b.Posts).ToList();
                    return Ok(new { message = "sikeres lek", result = bloggerWithPosts });
                }
               
                
            }
            catch (Exception)
            {

                return NotFound(new { message = "Sikertelen lek"});
            }
        }

        [HttpGet("withpost/{id}")]
        public IActionResult GetBloggerWithPostById(int id)
        {
            try
            {
                using (var  context = new BlogDbContext())
                {
                    var blog = context.bloggers.Include(b => b.Posts).FirstOrDefault(x => x.Id == id);
                    return Ok(new { message = "sikeres lek", result = blog });

                }
            }
            catch (Exception)
            {

                return NotFound(new { message = "Sikertelen lek" });
            }
        }

        [HttpGet("withpost/column/{id}")]
        public IActionResult GetBloggerWithPostByIdSpecificColumn(int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var items = context.bloggers
                     .Where(x => x.Id == id)
                     .Select(x => new
                     {
                         P1 = x.Name,
                         P2 = x.Posts.Select(p => p.Category)
                     }).FirstOrDefault();
                    return Ok(new { message = "sikeres lek", result = items });

                }
            }
            catch (Exception)
            {

                return NotFound(new { message = "Sikertelen lek" });
            }
        }

    }
}
