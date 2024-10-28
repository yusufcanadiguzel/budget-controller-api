using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Business.Logging.Contracts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;

namespace BudgetControllerApi.Business.Concrete
{
    public class StoreManager : IStoreService
    {
        private readonly IRepositoryService _service;
        private readonly ILoggerService _logger;

        public StoreManager(IRepositoryService service, ILoggerService logger)
        {
            _service = service;
            _logger = logger;
        }

        public void CreateOneStore(Store store)
        {
            _service.StoreRepository.CreateOneStore(store: store);

            _service.Save();
        }

        public void DeleteOneStore(int id)
        {
            var store = _service.StoreRepository.GetOneStoreById(id: id, trackChanges: false);

            if (store is null)
            {
                string message = $"Store with id: {id} could not found";

                _logger.LogInfo(message);

                throw new Exception(message);
            }
                
            _service.StoreRepository.DeleteOneStore(store: store);

            _service.Save();
        }

        public IEnumerable<Store> GetAllStores(bool trackChanges)
        {
            var stores = _service.StoreRepository.GetAllStores(trackChanges: trackChanges);

            return stores;
        }

        public Store GetOneStoreById(int id, bool trackChanges)
        {
            var store = _service.StoreRepository.GetOneStoreById(id:id, trackChanges: trackChanges);

            return store;
        }

        public void UpdateOneStore(int id, Store store, bool trackChanges)
        {
            var storeEntity = _service.StoreRepository.GetOneStoreById(id: id, trackChanges: trackChanges);

            if (storeEntity is null)
            {
                string message = $"Store with id: {id} could not found";

                _logger.LogInfo(message);

                throw new Exception(message);
            }
                

            if (store is null)
                throw new ArgumentNullException(nameof(store));

            storeEntity.Name = store.Name;
            storeEntity.Address = store.Address;
            storeEntity.TaxNumber = store.TaxNumber;

            _service.StoreRepository.UpdateOneStore(store: storeEntity);

            _service.Save();
        }
    }
}
