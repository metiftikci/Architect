using Architect.ApplicationCore.Models;
using Architect.ApplicationCore.Repositories;
using Architect.ApplicationCore.Services;

namespace Architect.Infrastructure.Services
{
    public class RecordService : EntityServiceBase<Record>, IRecordService
    {
        public RecordService(IServiceUnit serviceUnit, IRepositoryUnit repositoryUnit) : base(serviceUnit, repositoryUnit) { }
    }
}
