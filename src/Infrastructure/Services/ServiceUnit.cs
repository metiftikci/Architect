using System;
using System.Linq;
using Architect.ApplicationCore.Repositories;
using Architect.ApplicationCore.Services;

namespace Architect.Infrastructure.Services
{
    public class ServiceUnit : IServiceUnit
    {
        public IUserService UserService => new UserService(this, RepositoryUnit);

        protected readonly IRepositoryUnit RepositoryUnit;

        public ServiceUnit(IRepositoryUnit repositoryUnit) => RepositoryUnit = repositoryUnit;

        public TService GetService<TService>()
        {
            var serviceType = typeof(TService);

            var property = GetType().GetProperties().Where(x => serviceType.IsAssignableFrom(x.PropertyType)).FirstOrDefault();

            if (property == null) throw new InvalidOperationException($"{serviceType.Name} service is not supported");

            return (TService)property.GetValue(this);
        }
    }
}
