using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.RequestFeatures.Concrete;

namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IStoreRepository : IRepositoryBase<Store>
    {
        Task<PagedList<Store>> GetAllStoresAsync(StoreRequestParameters storeRequestParameters, bool trackChanges);
        Task<Store> GetOneStoreByIdAsync(int id, bool trackChanges);
        void CreateOneStore(Store store);
        void UpdateOneStore(Store store);
        void DeleteOneStore(Store store);
    }
}
