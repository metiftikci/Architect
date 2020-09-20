using System.Threading.Tasks;
using Architect.ApplicationCore.Models;

namespace Architect.ApplicationCore.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> FindByUsernameAsync(string username);
    }
}
