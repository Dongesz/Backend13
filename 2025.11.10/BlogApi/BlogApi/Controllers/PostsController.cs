using BlogApi.Model;
using BlogApi.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddPost(AddPostDto addPostDto)
        {
            var post = new Posts
            {
                Category = addPostDto.Category,
                Post = addPostDto.Post,
                Regtime = DateTime.Now,
                Modtime = DateTime.Now,
                BloggerId = addPostDto.BloggerId
            };

            try
            {
                using(var context = new BlogDbContext())
                {
                    if (post != null)
                    {
                        context.posts.Add(post);
                        context.SaveChanges();
                        return StatusCode(201, new {message = "Sikeres hozzaadas", result = post});
                    }
                    return BadRequest(new { message = "sikertelen hozzaadas", result = post });

                }
            }
            catch (Exception)
            {

                return BadRequest(new { message = "sikertelen hozzaadas", result = post });
            }
        }
        [HttpGet]
        public IActionResult GetPost()
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var posts = context.posts.ToList();
                    return Ok(posts);
                }
            }
            catch (Exception)
            {

                return BadRequest(new {message = "sikertelen lekerdezes"});
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var posts = context.posts.FirstOrDefault(x => x.Id == id);
                    return Ok(posts);
                }
            }
            catch (Exception)
            {

                return BadRequest(new { message = "sikertelen lekerdezes" });
            }
        }

        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var post = context.posts.FirstOrDefault(x => x.Id == id);
                    context.posts.Remove(post);
                    context.SaveChanges();
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return BadRequest(new { message = "sikertelen lekerdezes" });
            }
        }

        [HttpPut]
        public IActionResult UpdatePost(int id, UpdatePostDto updatePostDto)
        {
            try
            {
                using(var context = new BlogDbContext())
                {
                    var post = context.posts.FirstOrDefault(x => x.Id == id);
                    post.Category = updatePostDto.Category;
                    post.Post = updatePostDto.Post;
                    post.Modtime = DateTime.Now;
                    context.SaveChanges();
                    return Ok(new {message = "Sikeres frissites!"});
                }
            }
            catch (Exception)
            {

                return BadRequest(new {message = "Sikertelen frissites!"});
            }
        }
    }
}
