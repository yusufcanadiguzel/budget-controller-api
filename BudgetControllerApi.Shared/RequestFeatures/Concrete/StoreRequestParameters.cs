using BudgetControllerApi.Shared.RequestFeatures.Abstract;

namespace BudgetControllerApi.Shared.RequestFeatures.Concrete
{
    public class StoreRequestParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
    }
}
