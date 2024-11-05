using AutoMapper;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Product;

namespace BudgetControllerApi.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryService repositoryService,  IMapper mapper)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateOneProductAsync(ProductDtoForCreate productDtoForCreate)
        {
            var product = _mapper.Map<Product>(productDtoForCreate);

            _repositoryService.ProductRepository.CreateOneProduct(product);

            await _repositoryService.SaveAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task DeleteOneProductAsync(int id)
        {
            var product = await GetOneProductByIdAndCheckExistsAsync(id: id, trackChanges: false);

            _repositoryService.ProductRepository.DeleteOneProduct(product: product);

            await _repositoryService.SaveAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await _repositoryService.ProductRepository.GetAllProductsAsync(trackChanges: trackChanges);

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productDtos;
        }

        public async Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var product = await _repositoryService.ProductRepository.GetOneProductByIdAsync(id: id, trackChanges: trackChanges);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<ProductDto> PartiallyUpdateProductUnitPrice(ProductDtoForUpdateUnitPrice productDtoForUpdateUnitPrice)
        {
            var product = await GetOneProductByIdAndCheckExistsAsync(id: productDtoForUpdateUnitPrice.Id, trackChanges: false);

            product.UnitPrice = productDtoForUpdateUnitPrice.UnitPrice;

            _repositoryService.ProductRepository.UpdateOneProduct(product);

            await _repositoryService.SaveAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<ProductDto> UpdateOneProductAsync(ProductDtoForUpdate productDtoForUpdate)
        {
            var product = await GetOneProductByIdAndCheckExistsAsync(id: productDtoForUpdate.Id, trackChanges: false);

            product = _mapper.Map<Product>(productDtoForUpdate);

            _repositoryService.ProductRepository.UpdateOneProduct(product);

            await _repositoryService.SaveAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        private async Task<Product> GetOneProductByIdAndCheckExistsAsync(int id, bool trackChanges)
        {
            var productDto = await GetOneProductByIdAsync(id:id, trackChanges: trackChanges);

            var product = _mapper.Map<Product>(productDto);

            return product;
        }
    }
}
