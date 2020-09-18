using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architect.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase { }
}
