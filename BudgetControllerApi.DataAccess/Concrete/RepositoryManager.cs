using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;

namespace BudgetControllerApi.DataAccess.Concrete
{
    public class RepositoryManager : IRepositoryService
    {
        private readonly BudgetControllerDbContext _context;

        private readonly Lazy<IStoreRepository> _storeRepository;
        private readonly Lazy<IReceiptRepository> _receiptRepository;

        public RepositoryManager(BudgetControllerDbContext context, IStoreRepository storeRepository, IReceiptRepository receiptRepository)
        {
            _context = context;

            _storeRepository = new Lazy<IStoreRepository>(() => storeRepository);
            _receiptRepository = new Lazy<IReceiptRepository>(() => receiptRepository);
        }

        public IStoreRepository StoreRepository => _storeRepository.Value;

        public IReceiptRepository ReceiptRepository => _receiptRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
