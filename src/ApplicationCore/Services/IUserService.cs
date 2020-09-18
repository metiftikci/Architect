using System.Threading.Tasks;
using Architect.ApplicationCore.Models;

namespace Architect.ApplicationCore.Services
{
    public interface IUserService
    {
        Task<User> FindByUsernameAsync(string username);
    }
}
