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

        public StoreDto CreateOneStore(StoreDtoForCreate storeDtoForCreate)
        {
            var store = _mapper.Map<Store>(storeDtoForCreate);

            _service.StoreRepository.CreateOneStore(store: store);

            _service.Save();

            var storeDto = _mapper.Map<StoreDto>(store);

            return storeDto;
        }

        public void DeleteOneStore(int id)
        {
            var store = _service.StoreRepository.GetOneStoreById(id: id, trackChanges: false);

            if (store is null)
                throw new StoreNotFoundException(id: id);
                
            _service.StoreRepository.DeleteOneStore(store: store);

            _service.Save();
        }

        public IEnumerable<StoreDto> GetAllStores(bool trackChanges)
        {
            var stores = _service.StoreRepository.GetAllStores(trackChanges: trackChanges);

            var storeDtos = _mapper.Map<IEnumerable<StoreDto>>(stores);

            return storeDtos;
        }   

        public StoreDto GetOneStoreById(int id, bool trackChanges)
        {
            var store = _service.StoreRepository.GetOneStoreById(id:id, trackChanges: trackChanges);

            if (store is null)
                throw new StoreNotFoundException(id: id);

            var storeDto = _mapper.Map<StoreDto>(store);

            return storeDto;
        }

        public (StoreDtoForUpdate storeDtoForUpdate, Store store) GetOneStoreForPatch(int id, bool trackChanges)
        {
            var store = _service.StoreRepository.GetOneStoreById(id: id, trackChanges: false);

            if (store is null)
                throw new StoreNotFoundException(id: id);

            var updateDto = _mapper.Map<StoreDtoForUpdate>(store);

            return (updateDto, store);
        }

        public void SaveChangesForPatch(StoreDtoForUpdate storeDtoForUpdate, Store store)
        {
            _mapper.Map(storeDtoForUpdate,  store);
            _service.Save();
        }

        public void UpdateOneStore(int id, StoreDtoForUpdate storeDto, bool trackChanges)
        {
            var storeEntity = _service.StoreRepository.GetOneStoreById(id: id, trackChanges: trackChanges);

            if (storeEntity is null)
                throw new StoreNotFoundException(id: id);

            storeEntity = _mapper.Map<Store>(storeDto);

            _service.StoreRepository.UpdateOneStore(store: storeEntity);

            _service.Save();
        }
    }
}
