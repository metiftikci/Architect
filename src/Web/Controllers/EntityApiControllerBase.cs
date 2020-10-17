using System.Threading.Tasks;
using Architect.ApplicationCore.Models;
using Architect.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Architect.Web.Controllers
{
    public abstract class EntityApiControllerBase<TModel> : ApiControllerBase
        where TModel : class, IEntity
    {
        protected readonly IServiceUnit ServiceUnit;

        protected EntityApiControllerBase(IServiceUnit serviceUnit) => ServiceUnit = serviceUnit;

        /// <summary>
        /// Get record
        /// </summary>
        /// <param name="id">Record reference</param>
        /// <returns>Record or <c>null</c></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<TModel?> FindAsync(int id)
            => await GetService().FindAsync(id);

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <returns>Inserted record with 201 (Created) status code</returns>
        [HttpPost]
        public virtual async Task<IActionResult> InsertAsync(TModel model)
        {
            await GetService().InsertAsync(model);

            return Created($"/api/{typeof(TModel).Name}s/{model.Id}", model);
        }

        /// <summary>
        /// Update record
        /// </summary>
        [HttpPatch]
        public virtual async Task<IActionResult> UpdateAsync(TModel model)
        {
            await GetService().UpdateAsync(model);

            return Ok();
        }

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="id">Record reference to delete</param>
        /// <returns>204 (No Content) status code</returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            await GetService().DeleteAsync(id);

            return NoContent();
        }

        private IEntityService<TModel> GetService()
            => ServiceUnit.GetService<IEntityService<TModel>>();
    }
}
