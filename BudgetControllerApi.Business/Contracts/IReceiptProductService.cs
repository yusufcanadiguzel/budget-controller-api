using BudgetControllerApi.Shared.Dtos.ReceiptProduct;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IReceiptProductService
    {
        Task<ReceiptProductDto> GetOneReceiptProductDto(int id, bool trackChanges);
        Task CreateOneReceiptProduct(ReceiptProductDtoForCreate receiptProductDtoForCreate);
    }
}
