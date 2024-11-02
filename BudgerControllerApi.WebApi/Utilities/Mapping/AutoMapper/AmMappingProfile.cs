using AutoMapper;
using BudgetControllerApi.Entities.Concrete;
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
        }
    }
}
