using System.Threading.Tasks;
using Architect.ApplicationCore.Models;
using Architect.ApplicationCore.Repositories;
using Architect.ApplicationCore.Services;

namespace Architect.Infrastructure.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(IServiceUnit serviceUnit, IRepositoryUnit repositoryUnit) : base(serviceUnit, repositoryUnit) { }

        public async Task<User?> FindByUsernameAsync(string username) => await RepositoryUnit.UserRepository.FindByUsernameAsync(username);
    }
}
