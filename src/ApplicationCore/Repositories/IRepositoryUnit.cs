using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Architect.ApplicationCore.Repositories
{
    public interface IRepositoryUnit
    {
        IUserRepository UserRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
