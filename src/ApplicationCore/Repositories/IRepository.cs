using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architect.ApplicationCore.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> ToListAsync();
        Task<TEntity> FindAsync(params object[] keyValues);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
