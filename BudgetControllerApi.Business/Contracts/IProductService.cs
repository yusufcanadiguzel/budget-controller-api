using BudgetControllerApi.Shared.Dtos.Product;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);
        Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> CreateOneProductAsync(ProductDtoForCreate productDtoForCreate);
        Task<ProductDto> UpdateOneProductAsync(ProductDtoForUpdate productDtoForUpdate);
        Task<ProductDto> PartiallyUpdateProductUnitPrice(ProductDtoForUpdateUnitPrice productDtoForUpdateUnitPrice);
        Task DeleteOneProductAsync(int id);
    }
}
