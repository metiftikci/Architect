using Architect.ApplicationCore.Models;
using Architect.ApplicationCore.Services;

namespace Architect.Web.Controllers
{
    public class RecordsController : EntityApiControllerBase<Record>
    {
        public RecordsController(IServiceUnit serviceUnit) : base(serviceUnit) { }
    }
}
