using AutoMapper;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Product;
using BudgetControllerApi.Shared.Dtos.Receipt;
using BudgetControllerApi.Shared.Dtos.ReceiptProduct;
using BudgetControllerApi.Shared.Dtos.Store;
using BudgetControllerApi.Shared.Dtos.User;

namespace BudgerControllerApi.WebApi.Utilities.Mapping.AutoMapper
{
    public class AmMappingProfile : Profile
    {
        public AmMappingProfile()
        {
            CreateMap<StoreDtoForUpdate, Store>().ReverseMap();
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDtoForCreate, Store>();
            CreateMap<UserDtoForRegistration, User>();

            CreateMap<ReceiptDtoForCreate, Receipt>();
            CreateMap<Receipt, ReceiptDto>().ReverseMap();
            CreateMap<ReceiptDtoForUpdate, Receipt>().ReverseMap();

            CreateMap<ProductDtoForCreate, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductDtoForUpdate, Product>();
            CreateMap<ProductDtoForUpdateUnitPrice, Product>();

            CreateMap<ReceiptProductDtoForCreate, ReceiptProduct>();
            CreateMap<ReceiptProduct, ReceiptProductDto>().ReverseMap();
        }
    }
}
