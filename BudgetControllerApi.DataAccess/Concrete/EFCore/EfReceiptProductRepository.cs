using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.ReceiptProduct;
using Microsoft.EntityFrameworkCore;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore
{
    public class EfReceiptProductRepository : EfRepositoryBase<ReceiptProduct>, IReceiptProductRepository
    {
        public EfReceiptProductRepository(BudgetControllerDbContext context) : base(context)
        {
        }

        public void CreateOneReceiptProduct(ReceiptProduct receiptProduct) => Create(receiptProduct);

        public async Task<List<ReceiptProduct>> GetAllReceiptProductsByReceiptId(int receiptId, bool trackChanges)
        {
            var receiptProducts = await FindByCondition(x => x.ReceiptId.Equals(receiptId), false).ToListAsync();

            return receiptProducts;
        }

        public async Task<ReceiptProduct> GetOneReceiptProduct(int id, bool trackChanges)
        {
            var receiptProduct = await FindByCondition(x => x.ReceiptId.Equals(id), trackChanges).FirstOrDefaultAsync();

            return receiptProduct;
        }
    }
}
