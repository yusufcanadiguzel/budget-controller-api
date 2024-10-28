namespace BudgetControllerApi.Entities.Exceptions.Contracts
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
