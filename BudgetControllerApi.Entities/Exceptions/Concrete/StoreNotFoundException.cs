using BudgetControllerApi.Entities.Exceptions.Contracts;

namespace BudgetControllerApi.Entities.Exceptions.Concrete
{
    public sealed class StoreNotFoundException : NotFoundException
    {
        public StoreNotFoundException(int id) : base($"The store with id: {id} could not found.")
        {
        }
    }
}
