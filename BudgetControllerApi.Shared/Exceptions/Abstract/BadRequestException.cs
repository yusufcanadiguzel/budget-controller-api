namespace BudgetControllerApi.Shared.Exceptions.Abstract
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base(message)
        {
            
        }
    }
}
