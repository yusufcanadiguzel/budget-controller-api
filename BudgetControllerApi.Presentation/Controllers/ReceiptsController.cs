﻿using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Presentation.ActionFilters;
using BudgetControllerApi.Shared.Dtos.Receipt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControllerApi.Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReceiptsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetAllReceiptsAsync()
        {
            var receipts = await _serviceManager.ReceiptService.GetAllReceiptsAsync(trackChanges: false);

            return Ok(receipts);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetOneReceiptByIdAsync([FromRoute(Name = "id")] int id)
        {
            var receipt = await _serviceManager.ReceiptService.GetOneReceiptByIdAsync(id: id, trackChanges: false);

            return Ok(receipt);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateOneReceipt([FromBody] ReceiptDtoForCreate receiptDtoForCreate)
        {
            var result = await _serviceManager.ReceiptService.CreateOneReceiptAsync(receiptDtoForCreate: receiptDtoForCreate);

            return StatusCode(201, result);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateOneReceipt([FromRoute(Name = "id")]int id, [FromBody] ReceiptDtoForUpdate receiptDtoForUpdate)
        {
            var result = await _serviceManager.ReceiptService.UpdateOneReceiptAsync(receiptDtoForUpdate: receiptDtoForUpdate, trackChanges: false);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteOneReceipt([FromRoute(Name = "id")] int id)
        {
            await _serviceManager.ReceiptService.DeleteOneReceiptAsync(id: id);

            return NoContent();
        }
    }
}
