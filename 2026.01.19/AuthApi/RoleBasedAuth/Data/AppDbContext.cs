using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Models;

namespace RoleBasedAuth.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}