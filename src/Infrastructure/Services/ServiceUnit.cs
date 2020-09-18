using System.Threading.Tasks;
using Architect.ApplicationCore.Repositories;
using Architect.ApplicationCore.Services;
using Microsoft.EntityFrameworkCore.Storage;

namespace Architect.Infrastructure.Services
{
    public class ServiceUnit : IServiceUnit
    {
        public IUserService UserService => new UserService(this, RepositoryUnit);

        protected readonly IRepositoryUnit RepositoryUnit;

        public ServiceUnit(IRepositoryUnit repositoryUnit) => RepositoryUnit = repositoryUnit;

        public IDbContextTransaction BeginTransaction() => RepositoryUnit.BeginTransaction();
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await RepositoryUnit.BeginTransactionAsync();

        public int SaveChanges() => RepositoryUnit.SaveChanges();
        public async Task<int> SaveChangesAsync() => await RepositoryUnit.SaveChangesAsync();
    }
}
