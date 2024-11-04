using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Receipt;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IReceiptService
    {
        Task<IEnumerable<ReceiptDto>> GetAllReceiptsAsync(bool trackChanges);
        Task<ReceiptDto> GetOneReceiptByIdAsync(int id, bool trackChanges);
        Task<ReceiptDto> CreateOneReceiptAsync(ReceiptDtoForCreate receiptDtoForCreate);
        Task UpdateOneReceiptAsync(ReceiptDtoForUpdate receiptDtoForUpdate, bool trackChanges);
        Task DeleteOneReceiptAsync(int id);
    }
}
