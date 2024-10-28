using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;

namespace BudgetControllerApi.DataAccess.Concrete
{
    public class RepositoryManager : IRepositoryService
    {
        private readonly BudgetControllerDbContext _context;

        private readonly Lazy<IStoreRepository> _storeRepository;

        public RepositoryManager(BudgetControllerDbContext context, IStoreRepository storeRepository)
        {
            _context = context;

            _storeRepository = new Lazy<IStoreRepository>(() => storeRepository);
        }

        public IStoreRepository StoreRepository => _storeRepository.Value;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
