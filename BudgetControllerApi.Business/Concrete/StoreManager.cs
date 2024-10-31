using AutoMapper;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Business.Logging.Contracts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Entities.Exceptions.Concrete;
using BudgetControllerApi.Shared.Dtos.Store;
using BudgetControllerApi.Shared.RequestFeatures.Concrete;

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

        public async Task<StoreDto> CreateOneStoreAsync(StoreDtoForCreate storeDtoForCreate)
        {
            var store = _mapper.Map<Store>(storeDtoForCreate);

            _service.StoreRepository.CreateOneStore(store: store);

            await _service.SaveAsync();

            var storeDto = _mapper.Map<StoreDto>(store);

            return storeDto;
        }

        public async Task DeleteOneStoreAsync(int id)
        {
            var store = await GetOneStoreByIdAndCheckExists(id: id, trackChanges: false);
                
            _service.StoreRepository.DeleteOneStore(store: store);

            await _service.SaveAsync();
        }

        public async Task<(IEnumerable<StoreDto> storeDtos, MetaData metaData)> GetAllStoresAsync(StoreRequestParameters storeRequestParameters, bool trackChanges)
        {
            var storesWithMetaData = await _service.StoreRepository.GetAllStoresAsync(storeRequestParameters: storeRequestParameters, trackChanges: trackChanges);

            var storeDtos = _mapper.Map<IEnumerable<StoreDto>>(storesWithMetaData);

            return (storeDtos, storesWithMetaData.MetaData);
        }   

        public async Task<StoreDto> GetOneStoreByIdAsync(int id, bool trackChanges)
        {
            var store = await GetOneStoreByIdAndCheckExists(id: id, trackChanges: trackChanges);

            var storeDto = _mapper.Map<StoreDto>(store);

            return storeDto;
        }

        public async Task<(StoreDtoForUpdate storeDtoForUpdate, Store store)> GetOneStoreForPatchAsync(int id, bool trackChanges)
        {
            var store = await GetOneStoreByIdAndCheckExists(id: id, trackChanges: trackChanges);

            var updateDto = _mapper.Map<StoreDtoForUpdate>(store);

            return (updateDto, store);
        }

        public async Task SaveChangesForPatchAsync(StoreDtoForUpdate storeDtoForUpdate, Store store)
        {
            _mapper.Map(storeDtoForUpdate,  store);
            await _service.SaveAsync();
        }

        public async Task UpdateOneStoreAsync(int id, StoreDtoForUpdate storeDto, bool trackChanges)
        {
            var storeEntity = await GetOneStoreByIdAndCheckExists(id: id, trackChanges: trackChanges);

            storeEntity = _mapper.Map<Store>(storeDto);

            _service.StoreRepository.UpdateOneStore(store: storeEntity);

            await _service.SaveAsync();
        }

        private async Task<Store> GetOneStoreByIdAndCheckExists(int id, bool trackChanges)
        {
            var store = await _service.StoreRepository.GetOneStoreByIdAsync(id: id, trackChanges: false);

            if (store is null)
                throw new StoreNotFoundException(id: id);

            return store;
        }
    }
}
