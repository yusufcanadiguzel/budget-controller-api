using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore
{
    public class EfStoreRepository : EfRepositoryBase<Store>, IStoreRepository
    {
        public EfStoreRepository(BudgetControllerDbContext context) : base(context)
        {
        }

        public void CreateOneStore(Store store) => Create(store);

        public void DeleteOneStore(Store store) => Delete(store);

        public async Task<IEnumerable<Store>> GetAllStoresAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();


        public async Task<Store> GetOneStoreByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneStore(Store store) => Update(store);
    }
}
