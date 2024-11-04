using BudgetControllerApi.Entities.Exceptions.Contracts;

namespace BudgetControllerApi.Entities.Exceptions.Concrete
{
    public sealed class ReceiptNotFoundException : NotFoundException
    {
        public ReceiptNotFoundException(int id) : base($"Receipt with id: {id} could not found.")
        {
        }
    }
}
