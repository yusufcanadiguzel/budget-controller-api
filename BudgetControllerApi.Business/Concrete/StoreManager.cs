using AutoMapper;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Business.Logging.Contracts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Entities.Exceptions.Concrete;
using BudgetControllerApi.Shared.Dtos.Store;

namespace BudgetControllerApi.Business.Concrete
{
    public class StoreManager : IStoreService
    {
        private readonly IRepositoryService _service;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public StoreManager(IRepositoryService service, ILoggerService logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
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
                throw new StoreNotFoundException(id: id);
                
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

            if (store is null)
                throw new StoreNotFoundException(id: id);

            return store;
        }

        public void UpdateOneStore(int id, StoreDtoForUpdate storeDto, bool trackChanges)
        {
            var storeEntity = _service.StoreRepository.GetOneStoreById(id: id, trackChanges: trackChanges);

            if (storeEntity is null)
                throw new StoreNotFoundException(id: id);

            _mapper.Map<Store>(storeDto);

            _service.StoreRepository.UpdateOneStore(store: storeEntity);

            _service.Save();
        }
    }
}
