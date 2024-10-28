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
        public IActionResult CreateOneStore([FromBody] Store store)
        {
            if (store is null)
                return BadRequest();

            _serviceManager.StoreService.CreateOneStore(store: store);

            return StatusCode(201, store);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneStore([FromRoute(Name = "id")] int id, [FromBody] StoreDtoForUpdate storeDto)
        {
            if (id != storeDto.Id)
                return BadRequest();

            _serviceManager.StoreService.UpdateOneStore(id: id, storeDto: storeDto, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneStore([FromRoute(Name = "id")] int id)
        {
            _serviceManager.StoreService.DeleteOneStore(id: id);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneStore([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Store> storePatch)
        {
            var storeEntity = _serviceManager.StoreService.GetOneStoreById(id: id, trackChanges: true);

            storePatch.ApplyTo(storeEntity);

            _serviceManager.StoreService.UpdateOneStore(id: id, storeDto: new StoreDtoForUpdate { Id = storeEntity.Id, Name = storeEntity.Name, Address = storeEntity.Address, TaxNumber = storeEntity.TaxNumber}, trackChanges: true);

            return NoContent();
        }
    }
}
