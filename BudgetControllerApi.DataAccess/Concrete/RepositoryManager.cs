using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using BudgetControllerApi.DataAccess.Contracts;

namespace BudgetControllerApi.DataAccess.Concrete
{
    public class RepositoryManager : IRepositoryService
    {
        private readonly BudgetControllerDbContext _context;

        private readonly Lazy<IStoreRepository> _storeRepository;
        private readonly Lazy<IReceiptRepository> _receiptRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IReceiptProductRepository> _receiptProductRepository;

        public RepositoryManager(BudgetControllerDbContext context, IStoreRepository storeRepository, IReceiptRepository receiptRepository, IProductRepository productRepository, IReceiptProductRepository receiptProductRepository)
        {
            _context = context;

            _storeRepository = new Lazy<IStoreRepository>(() => storeRepository);
            _receiptRepository = new Lazy<IReceiptRepository>(() => receiptRepository);
            _productRepository = new Lazy<IProductRepository>(() => productRepository);
            _receiptProductRepository = new Lazy<IReceiptProductRepository>(() => receiptProductRepository);
        }

        public IStoreRepository StoreRepository => _storeRepository.Value;

        public IReceiptRepository ReceiptRepository => _receiptRepository.Value;

        public IProductRepository ProductRepository => _productRepository.Value;

        public IReceiptProductRepository ReceiptProductRepository => _receiptProductRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
