using Architect.ApplicationCore.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Architect.Web.Controllers
{
    public class SystemController : ApiControllerBase
    {
        [HttpGet("Version")]
        public string GetVersion()
        {
            return Version.GetVersion();
        }
    }
}
