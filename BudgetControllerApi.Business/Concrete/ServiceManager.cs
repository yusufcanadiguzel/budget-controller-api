using BudgetControllerApi.Business.Contracts;

namespace BudgetControllerApi.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreService> _storeService;

        public ServiceManager(IStoreService storeService)
        {
            _storeService = new Lazy<IStoreService>(() => storeService);
        }

        public IStoreService StoreService => _storeService.Value;
    }
}
