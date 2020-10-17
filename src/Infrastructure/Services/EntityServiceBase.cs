using System;
using System.Threading.Tasks;
using Architect.ApplicationCore.Models;
using Architect.ApplicationCore.Repositories;
using Architect.ApplicationCore.Services;

namespace Architect.Infrastructure.Services
{
    public abstract class EntityServiceBase<TModel> : ServiceBase, IEntityService<TModel>
        where TModel : class, IEntity
    {
        protected EntityServiceBase(IServiceUnit serviceUnit, IRepositoryUnit repositoryUnit) : base(serviceUnit, repositoryUnit) { }

        public virtual async Task<TModel?> FindAsync(int id)
            => await GetRepository().FindAsync(id);

        public virtual async Task InsertAsync(TModel entity)
        {
            GetRepository().Add(entity);

            await RepositoryUnit.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TModel entity)
        {
            GetRepository().Add(entity);

            await RepositoryUnit.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await FindAsync(id);

            if (entity == null) throw new InvalidOperationException($"Record not found by reference. Id: {id}");

            GetRepository().Remove(entity);

            await RepositoryUnit.SaveChangesAsync();
        }

        private IRepository<TModel> GetRepository()
            => RepositoryUnit.GetRepository<IRepository<TModel>>();
    }
}
