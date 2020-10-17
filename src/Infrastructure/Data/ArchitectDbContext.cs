using Architect.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Architect.Infrastructure.Data
{
    public class ArchitectDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Record> Records => Set<Record>();

        public ArchitectDbContext(DbContextOptions<ArchitectDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Username);
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.Role });

            modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "Admin", LastName = "Architect", Username = "admin", Password = "123456" });
            modelBuilder.Entity<UserRole>().HasData(new UserRole() { UserId = 1, Role = UserRole.Administrator });
        }
    }
}
