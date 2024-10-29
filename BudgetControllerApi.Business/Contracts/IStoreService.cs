﻿using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Store;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreDto>> GetAllStoresAsync(bool trackChanges);
        Task<StoreDto> GetOneStoreByIdAsync(int id, bool trackChanges);
        Task<StoreDto> CreateOneStoreAsync(StoreDtoForCreate storeDtoForCreate);
        Task UpdateOneStoreAsync(int id, StoreDtoForUpdate storeDto, bool trackChanges);
        Task DeleteOneStoreAsync(int id);
        Task<(StoreDtoForUpdate storeDtoForUpdate, Store store)> GetOneStoreForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(StoreDtoForUpdate storeDtoForUpdate, Store store);
    }
}
