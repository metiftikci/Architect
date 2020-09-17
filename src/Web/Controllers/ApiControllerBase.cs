using Microsoft.AspNetCore.Mvc;

namespace Architect.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase { }
}
