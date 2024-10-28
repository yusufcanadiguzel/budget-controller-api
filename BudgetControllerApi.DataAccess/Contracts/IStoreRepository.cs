using BudgetControllerApi.Entities.Concrete;

namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IStoreRepository : IRepositoryBase<Store>
    {
        IQueryable<Store> GetAllStores(bool trackChanges);
        Store GetOneStoreById(int id, bool trackChanges);
        void CreateOneStore(Store store);
        void UpdateOneStore(Store store);
        void DeleteOneStore(Store store);
    }
}
