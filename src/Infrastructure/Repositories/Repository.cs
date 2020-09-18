using System.Collections.Generic;
using System.Threading.Tasks;
using Architect.ApplicationCore.Repositories;
using Architect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Architect.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly ArchitectDbContext DbContext;

        public Repository(ArchitectDbContext dbContext) => DbContext = dbContext;

        public async Task<List<TEntity>> ToListAsync() => await DbContext.Set<TEntity>().ToListAsync();
        public async Task<TEntity> FindAsync(params object[] keyValues) => await DbContext.Set<TEntity>().FindAsync(keyValues);
        public void Add(TEntity entity) => DbContext.Add(entity);
        public void Update(TEntity entity) => DbContext.Update(entity);
        public void Remove(TEntity entity) => DbContext.Remove(entity);
    }
}
