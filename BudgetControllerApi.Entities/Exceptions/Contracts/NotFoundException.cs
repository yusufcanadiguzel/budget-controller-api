namespace BudgetControllerApi.Entities.Exceptions.Concrete
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {
            
        }
    }
}
