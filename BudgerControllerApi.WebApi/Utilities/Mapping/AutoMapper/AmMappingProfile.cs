using AutoMapper;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Store;

namespace BudgerControllerApi.WebApi.Utilities.Mapping.AutoMapper
{
    public class AmMappingProfile : Profile
    {
        public AmMappingProfile()
        {
            CreateMap<StoreDtoForUpdate, Store>();
        }
    }
}
