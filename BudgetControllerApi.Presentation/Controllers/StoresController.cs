using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Entities.Exceptions.Concrete;
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
        public IActionResult GetAllStores()
        {
            var stores = _serviceManager.StoreService.GetAllStores(trackChanges: false);

            return Ok(stores);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneStoreById([FromRoute(Name = "id")] int id)
        {
            var store = _serviceManager.StoreService.GetOneStoreById(id: id, trackChanges: false);

            return Ok(store);
        }

        [HttpPost]
        public IActionResult CreateOneStore([FromBody] StoreDtoForCreate storeDtoForCreate)
        {
            if (storeDtoForCreate is null)
                return BadRequest();

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var storeDto = _serviceManager.StoreService.CreateOneStore(storeDtoForCreate: storeDtoForCreate);

            return StatusCode(201, storeDto);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneStore([FromRoute(Name = "id")] int id, [FromBody] StoreDtoForUpdate storeDto)
        {
            if (id != storeDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _serviceManager.StoreService.UpdateOneStore(id: id, storeDto: storeDto, trackChanges: false);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneStore([FromRoute(Name = "id")] int id)
        {
            _serviceManager.StoreService.DeleteOneStore(id: id);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneStore([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<StoreDtoForUpdate> storePatch)
        {
            if (storePatch is null)
                return BadRequest();

            var result = _serviceManager.StoreService.GetOneStoreForPatch(id: id, trackChanges: false);

            storePatch.ApplyTo(result.storeDtoForUpdate, ModelState);

            TryValidateModel(result.storeDtoForUpdate);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _serviceManager.StoreService.SaveChangesForPatch(result.storeDtoForUpdate, result.store);

            return NoContent();
        }
    }
}
