using Microsoft.EntityFrameworkCore;

namespace UserRoleApi.Models
{
    public class DatabaseContext : DbContext
    {
       
        protected DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost; database=AuthUser; user=root; password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ru => new { ru.UserId, ru.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ru => ru.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ru => ru.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ru => ru.Roles)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ru => ru.RoleId);
        }
    }
}

