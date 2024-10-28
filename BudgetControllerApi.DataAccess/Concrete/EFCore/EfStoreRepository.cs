using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore
{
    public class EfStoreRepository : EfRepositoryBase<Store>, IStoreRepository
    {
        public EfStoreRepository(BudgetControllerDbContext context) : base(context)
        {
        }

        public void CreateOneStore(Store store) => Create(store);

        public void DeleteOneStore(Store store) => Delete(store);

        public IQueryable<Store> GetAllStores(bool trackChanges) => FindAll(trackChanges);


        public Store GetOneStoreById(int id, bool trackChanges) => FindByCondition(s => s.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneStore(Store store) => Update(store);
    }
}
