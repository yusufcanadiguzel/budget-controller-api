namespace BudgetControllerApi.Business.Contracts
{
    public interface IServiceManager
    {
        public IStoreService StoreService { get; }
        public IAuthenticationService AuthenticationService { get; }
        public IReceiptService ReceiptService { get; }
        public IProductService ProductService { get; }
        //public IReceiptProductService ReceiptProductService { get; }
    }
}
