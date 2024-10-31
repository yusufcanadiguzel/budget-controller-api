using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Presentation.ActionFilters;
using BudgetControllerApi.Shared.Dtos.Store;
using BudgetControllerApi.Shared.RequestFeatures.Concrete;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BudgetControllerApi.Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public StoresController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStoresAsync([FromQuery] StoreRequestParameters storeRequestParameters)
        {
            var pagedResult = await _serviceManager.StoreService.GetAllStoresAsync(storeRequestParameters: storeRequestParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.storeDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneStoreByIdAsync([FromRoute(Name = "id")] int id)
        {
            var store = await _serviceManager.StoreService.GetOneStoreByIdAsync(id: id, trackChanges: false);

            return Ok(store);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneStoreAsync([FromBody] StoreDtoForCreate storeDtoForCreate)
        {
            var storeDto = await _serviceManager.StoreService.CreateOneStoreAsync(storeDtoForCreate: storeDtoForCreate);

            return StatusCode(201, storeDto);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneStoreAsync([FromRoute(Name = "id")] int id, [FromBody] StoreDtoForUpdate storeDto)
        {
            await _serviceManager.StoreService.UpdateOneStoreAsync(id: id, storeDto: storeDto, trackChanges: false);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneStoreAsync([FromRoute(Name = "id")] int id)
        {
            await _serviceManager.StoreService.DeleteOneStoreAsync(id: id);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneStoreAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<StoreDtoForUpdate> storePatch)
        {
            if (storePatch is null)
                return BadRequest();

            var result = await _serviceManager.StoreService.GetOneStoreForPatchAsync(id: id, trackChanges: false);

            storePatch.ApplyTo(result.storeDtoForUpdate, ModelState);

            TryValidateModel(result.storeDtoForUpdate);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.StoreService.SaveChangesForPatchAsync(result.storeDtoForUpdate, result.store);

            return NoContent();
        }
    }
}
