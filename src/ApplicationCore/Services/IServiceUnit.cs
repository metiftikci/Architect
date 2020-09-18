using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Architect.ApplicationCore.Services
{
    public interface IServiceUnit
    {
        IUserService UserService { get; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
