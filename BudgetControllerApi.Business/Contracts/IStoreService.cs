using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Store;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IStoreService
    {
        IEnumerable<StoreDto> GetAllStores(bool trackChanges);
        StoreDto GetOneStoreById(int id, bool trackChanges);
        StoreDto CreateOneStore(StoreDtoForCreate storeDtoForCreate);
        void UpdateOneStore(int id, StoreDtoForUpdate storeDto, bool trackChanges);
        void DeleteOneStore(int id);
        (StoreDtoForUpdate storeDtoForUpdate, Store store) GetOneStoreForPatch(int id, bool trackChanges);
        void SaveChangesForPatch(StoreDtoForUpdate storeDtoForUpdate, Store store);
    }
}
