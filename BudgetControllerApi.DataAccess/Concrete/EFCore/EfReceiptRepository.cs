using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore
{
    public class EfReceiptRepository : EfRepositoryBase<Receipt>, IReceiptRepository
    {
        public EfReceiptRepository(BudgetControllerDbContext context) : base(context)
        {
        }

        public void CreateOneReceipt(Receipt receipt) => Create(entity: receipt);

        public void DeleteOneReceipt(Receipt receipt) => Delete(entity: receipt);

        public async Task<IEnumerable<Receipt>> GetAllReceiptsAsync(bool trackChanges)
        {
            var receipts = await FindAll(trackChanges: trackChanges).ToListAsync();

            return receipts;
        }

        public async Task<Receipt> GetOneReceiptByIdAsync(int id, bool trackChanges)
        {
            var receipt = await FindByCondition(expression: r => r.Id.Equals(id), trackChanges: trackChanges).FirstOrDefaultAsync();

            return receipt;
        }

        public void UpdateOneReceipt(Receipt receipt) => Update(entity: receipt);
    }
}
