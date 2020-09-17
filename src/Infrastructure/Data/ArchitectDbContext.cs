using Architect.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Architect.Infrastructure.Data
{
    public class ArchitectDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public ArchitectDbContext(DbContextOptions<ArchitectDbContext> options) : base(options) { }
    }
}
