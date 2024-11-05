using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.ReceiptProduct;

namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IReceiptProductRepository : IRepositoryBase<ReceiptProduct>
    {
        Task<ReceiptProduct> GetOneReceiptProduct(int id, bool trackChanges);
        Task<List<ReceiptProduct>> GetAllReceiptProductsByReceiptId(int receiptId, bool trackChanges);
        void CreateOneReceiptProduct(ReceiptProduct receiptProduct);
    }
}
