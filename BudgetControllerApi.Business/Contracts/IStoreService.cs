using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Store;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IStoreService
    {
        IEnumerable<Store> GetAllStores(bool trackChanges);
        Store GetOneStoreById(int id, bool trackChanges);
        void CreateOneStore(Store store);
        void UpdateOneStore(int id, StoreDtoForUpdate storeDto, bool trackChanges);
        void DeleteOneStore(int id);
    }
}
