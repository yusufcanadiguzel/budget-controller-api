using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Entities.Concrete;
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
            try
            {
                var stores = _serviceManager.StoreService.GetAllStores(trackChanges: false);

                return Ok(stores);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneStoreById([FromRoute(Name = "id")] int id)
        {
            try
            {
                var store = _serviceManager.StoreService.GetOneStoreById(id: id, trackChanges: false);

                if (store is null)
                    return NotFound();
                else
                    return Ok(store);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneStore([FromBody] Store store)
        {
            try
            {
                if (store is null)
                    return BadRequest();

                _serviceManager.StoreService.CreateOneStore(store: store);

                return StatusCode(201, store);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneStore([FromRoute(Name = "id")] int id, [FromBody] Store store)
        {
            try
            {
                if (id != store.Id)
                    return BadRequest();

                _serviceManager.StoreService.UpdateOneStore(id: id, store: store, trackChanges: true);

                return NoContent();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneStore([FromRoute(Name = "id")] int id)
        {
            try
            {
                _serviceManager.StoreService.DeleteOneStore(id: id);

                return NoContent();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneStore([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Store> storePatch)
        {
            try
            {
                var storeEntity = _serviceManager.StoreService.GetOneStoreById(id: id, trackChanges: true);

                if (storeEntity is null)
                    return NotFound();

                storePatch.ApplyTo(storeEntity);

                _serviceManager.StoreService.UpdateOneStore(id: id, store: storeEntity, trackChanges: true);

                return NoContent();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
