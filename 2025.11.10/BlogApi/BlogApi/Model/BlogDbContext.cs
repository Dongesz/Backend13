using Microsoft.EntityFrameworkCore;
namespace BlogApi.Model
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Blogger> bloggers { get; set; }
        public DbSet<Posts> posts { get; set; }
        public BlogDbContext()
        {

        }
        public BlogDbContext(DbContextOptions options) :base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseMySQL("SERVER=localhost;DATABASE=Blog;USER=root;PASSWORD=");
        }
    }
}
