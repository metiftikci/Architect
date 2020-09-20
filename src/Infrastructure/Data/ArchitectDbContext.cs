using Architect.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Architect.Infrastructure.Data
{
    public class ArchitectDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public ArchitectDbContext(DbContextOptions<ArchitectDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Username);

            modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "Admin", LastName = "Architect", Username = "admin", Password = "123456" });
        }
    }
}
