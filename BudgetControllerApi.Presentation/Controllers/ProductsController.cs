using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Presentation.ActionFilters;
using BudgetControllerApi.Shared.Dtos.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControllerApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync(trackChanges: false);

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOneProductById([FromRoute(Name = "id")] int id)
        {
            var product = await _serviceManager.ProductService.GetOneProductByIdAsync(id: id, trackChanges: false);

            return Ok(product);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOneProduct([FromBody] ProductDtoForCreate productDtoForCreate)
        {
            await _serviceManager.ProductService.CreateOneProductAsync(productDtoForCreate);

            return StatusCode(201, productDtoForCreate);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productDtoForUpdate)
        {
            var result = await _serviceManager.ProductService.UpdateOneProductAsync(productDtoForUpdate);

            return Ok(result);
        }

        [HttpPatch("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PartiallyUpdateProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdateUnitPrice productDtoForUpdateUnitPrice)
        {
            var result = await _serviceManager.ProductService.PartiallyUpdateProductUnitPrice(productDtoForUpdateUnitPrice);

            return Ok(result);
        }
    }
}
