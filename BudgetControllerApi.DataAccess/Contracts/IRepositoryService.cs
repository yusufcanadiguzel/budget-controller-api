﻿namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IRepositoryService
    {
        IStoreRepository StoreRepository { get; }

        Task SaveAsync();
    }
}
