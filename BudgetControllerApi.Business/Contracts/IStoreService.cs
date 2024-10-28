using BudgetControllerApi.Entities.Concrete;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IStoreService
    {
        IEnumerable<Store> GetAllStores(bool trackChanges);
        Store GetOneStoreById(int id, bool trackChanges);
        void CreateOneStore(Store store);
        void UpdateOneStore(int id, Store store, bool trackChanges);
        void DeleteOneStore(int id);
    }
}
