namespace BudgetControllerApi.Business.Contracts
{
    public interface IServiceManager
    {
        public IStoreService StoreService { get; }
        public IAuthenticationService AuthenticationService { get; }
    }
}
