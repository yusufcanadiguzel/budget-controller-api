using BudgetControllerApi.Shared.RequestFeatures.Abstract;

namespace BudgetControllerApi.Shared.RequestFeatures.Concrete
{
    public class ProductRequestParameters : RequestParameters
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = uint.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}
