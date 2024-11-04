using BudgetControllerApi.Entities.Concrete;

namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetAllReceiptsAsync(bool trackChanges);
        Task<Receipt> GetOneReceiptByIdAsync(int id, bool trackChanges);
        void CreateOneReceipt(Receipt receipt);
        void UpdateOneReceipt(Receipt receipt);
        void DeleteOneReceipt(Receipt receipt);
    }
}
