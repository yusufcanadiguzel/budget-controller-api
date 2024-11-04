namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IRepositoryService
    {
        IStoreRepository StoreRepository { get; }
        IReceiptRepository ReceiptRepository { get; }

        Task SaveAsync();
    }
}
