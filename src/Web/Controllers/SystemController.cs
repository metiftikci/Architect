using Architect.ApplicationCore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architect.Web.Controllers
{
    public class SystemController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpGet("Version")]
        public string GetVersion()
        {
            return Version.GetVersion();
        }
    }
}
