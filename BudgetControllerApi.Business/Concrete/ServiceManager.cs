using BudgetControllerApi.Business.Contracts;

namespace BudgetControllerApi.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreService> _storeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IReceiptService> _receiptService;
        private readonly Lazy<IProductService> _productService;
        //private readonly Lazy<IReceiptProductService> _receiptProductService;

        public ServiceManager(IStoreService storeService, IAuthenticationService authenticationService, IReceiptService receiptService, IProductService productService)
        {
            _storeService = new Lazy<IStoreService>(() => storeService);
            _authenticationService = new Lazy<IAuthenticationService>(() => authenticationService);
            _receiptService = new Lazy<IReceiptService>(() => receiptService);
            _productService = new Lazy<IProductService>(() => productService);
            //_receiptProductService = new Lazy<IReceiptProductService>(() => receiptProductService);
        }

        public IStoreService StoreService => _storeService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IReceiptService ReceiptService => _receiptService.Value;

        public IProductService ProductService => _productService.Value;

        //public IReceiptProductService ReceiptProductService => _receiptProductService.Value;
    }
}
