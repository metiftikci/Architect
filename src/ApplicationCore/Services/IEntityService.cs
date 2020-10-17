using System.Threading.Tasks;
using Architect.ApplicationCore.Models;

namespace Architect.ApplicationCore.Services
{
    public interface IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity?> FindAsync(int id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
