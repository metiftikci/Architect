using System.Threading.Tasks;
using Architect.ApplicationCore.Services;
using Architect.Web.Models;
using Architect.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architect.Web.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IServiceUnit _serviceUnit;

        public UsersController(IServiceUnit serviceUnit) => _serviceUnit = serviceUnit;

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest model)
        {
            try
            {
                return await new AuthUtils(_serviceUnit).Authenticate(model);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
