using BudgetControllerApi.Business.Contracts;

namespace BudgetControllerApi.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreService> _storeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IStoreService storeService, IAuthenticationService authenticationService)
        {
            _storeService = new Lazy<IStoreService>(() => storeService);
            _authenticationService = new Lazy<IAuthenticationService>(() => authenticationService);
        }

        public IStoreService StoreService => _storeService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
