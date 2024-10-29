using BudgetControllerApi.Entities.Concrete;

namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IStoreRepository : IRepositoryBase<Store>
    {
        Task<IEnumerable<Store>> GetAllStoresAsync(bool trackChanges);
        Task<Store> GetOneStoreByIdAsync(int id, bool trackChanges);
        void CreateOneStore(Store store);
        void UpdateOneStore(Store store);
        void DeleteOneStore(Store store);
    }
}
