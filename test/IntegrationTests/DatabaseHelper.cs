using System.Collections.Generic;
using Architect.ApplicationCore.Models;
using Architect.Infrastructure.Data;

namespace Architect.IntegrationTests
{
    public static class DatabaseHelper
    {
        public static void Seed(ArchitectDbContext dbContext)
        {
            dbContext.Add(new User() { FirstName = "Name", LastName = "Surname", Username = "admin", Password = "123456" });
            dbContext.Add(new Record() { Description = "Record 1" });

            dbContext.SaveChanges();
        }
    }
}
