using System.Threading.Tasks;
using Architect.ApplicationCore.Models;
using Architect.ApplicationCore.Repositories;
using Architect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Architect.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ArchitectDbContext dbContext) : base(dbContext) { }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await DbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
