using BudgetControllerApi.Shared.Exceptions.Abstract;

namespace BudgetControllerApi.Shared.Exceptions.Concrete
{
    public sealed class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException() : base("Price should be valid value.")
        {
        }
    }
}
