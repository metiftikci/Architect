using Architect.ApplicationCore.Repositories;
using Architect.ApplicationCore.Services;

namespace Architect.Infrastructure.Services
{
    public abstract class ServiceBase
    {
        protected readonly IServiceUnit ServiceUnit;
        protected readonly IRepositoryUnit RepositoryUnit;

        public ServiceBase(IServiceUnit serviceUnit, IRepositoryUnit repositoryUnit)
            => (ServiceUnit, RepositoryUnit) = (serviceUnit, repositoryUnit);
    }
}
