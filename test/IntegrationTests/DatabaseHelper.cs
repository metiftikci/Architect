using System.Collections.Generic;
using Architect.ApplicationCore.Models;
using Architect.Infrastructure.Data;

namespace Architect.IntegrationTests
{
    public static class DatabaseHelper
    {
        public static void Seed(ArchitectDbContext dbContext)
        {
            dbContext.AddRange(GetUsers());

            dbContext.SaveChanges();
        }

        private static List<User> GetUsers() => new List<User>()
        {
            new User() { FirstName = "Name", LastName = "Surname", Username = "admin", Password = "123456" }
        };
    }
}
