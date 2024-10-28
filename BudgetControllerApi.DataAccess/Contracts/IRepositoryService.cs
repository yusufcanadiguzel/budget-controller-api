namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IRepositoryService
    {
        IStoreRepository StoreRepository { get; }

        void Save();
    }
}
