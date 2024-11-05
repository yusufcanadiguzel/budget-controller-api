using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore
{
    public class EfProductRepository : EfRepositoryBase<Product>, IProductRepository
    {
        public EfProductRepository(BudgetControllerDbContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(entity: product);

        public void DeleteOneProduct(Product product) => Delete(entity: product);

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await FindAll(trackChanges: trackChanges).ToListAsync();

            return products;
        }

        public async Task<Product> GetOneProductByIdAsync(int id, bool trackChanges) => await FindByCondition(p => p.Id.Equals(id), trackChanges: trackChanges).FirstOrDefaultAsync();
        public void UpdateOneProduct(Product product) => Update(entity: product);
    }
}
