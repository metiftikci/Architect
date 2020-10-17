using Architect.ApplicationCore.Repositories;
using Architect.ApplicationCore.Services;

namespace Architect.Infrastructure.Services
{
    public abstract class ServiceBase
    {
        protected readonly IServiceUnit ServiceUnit;
        protected readonly IRepositoryUnit RepositoryUnit;

        protected ServiceBase(IServiceUnit serviceUnit, IRepositoryUnit repositoryUnit)
            => (ServiceUnit, RepositoryUnit) = (serviceUnit, repositoryUnit);
    }
}
