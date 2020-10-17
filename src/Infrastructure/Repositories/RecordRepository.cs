using Architect.ApplicationCore.Models;
using Architect.ApplicationCore.Repositories;
using Architect.Infrastructure.Data;

namespace Architect.Infrastructure.Repositories
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(ArchitectDbContext dbContext) : base(dbContext) { }
    }
}
