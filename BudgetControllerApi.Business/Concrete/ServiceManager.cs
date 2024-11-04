using BudgetControllerApi.Business.Contracts;

namespace BudgetControllerApi.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreService> _storeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IReceiptService> _receiptService;

        public ServiceManager(IStoreService storeService, IAuthenticationService authenticationService, IReceiptService receiptService)
        {
            _storeService = new Lazy<IStoreService>(() => storeService);
            _authenticationService = new Lazy<IAuthenticationService>(() => authenticationService);
            _receiptService = new Lazy<IReceiptService>(() => receiptService);
        }

        public IStoreService StoreService => _storeService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IReceiptService ReceiptService => _receiptService.Value;
    }
}
