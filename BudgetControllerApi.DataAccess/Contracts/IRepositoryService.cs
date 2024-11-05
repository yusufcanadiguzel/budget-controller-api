namespace BudgetControllerApi.DataAccess.Contracts
{
    public interface IRepositoryService
    {
        IStoreRepository StoreRepository { get; }
        IReceiptRepository ReceiptRepository { get; }
        IProductRepository ProductRepository { get; }
        IReceiptProductRepository ReceiptProductRepository { get; }

        Task SaveAsync();
    }
}
