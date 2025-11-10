using Microsoft.EntityFrameworkCore;
namespace BlogApi.Model
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {

        }
        public BlogDbContext(DbContextOptions options) :base(options) 
        {

        }
    }
}
