using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Shared.Dtos.Store;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControllerApi.Presentation.Controllers
{
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
        public async Task<IActionResult> GetAllStoresAsync()
        {
            var stores = await _serviceManager.StoreService.GetAllStoresAsync(trackChanges: false);

            return Ok(stores);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneStoreByIdAsync([FromRoute(Name = "id")] int id)
        {
            var store = await _serviceManager.StoreService.GetOneStoreByIdAsync(id: id, trackChanges: false);

            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneStoreAsync([FromBody] StoreDtoForCreate storeDtoForCreate)
        {
            if (storeDtoForCreate is null)
                return BadRequest();

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var storeDto = await _serviceManager.StoreService.CreateOneStoreAsync(storeDtoForCreate: storeDtoForCreate);

            return StatusCode(201, storeDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneStoreAsync([FromRoute(Name = "id")] int id, [FromBody] StoreDtoForUpdate storeDto)
        {
            if (id != storeDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

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
