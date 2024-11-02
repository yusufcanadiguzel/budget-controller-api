using BudgetControllerApi.Shared.Exceptions.Abstract;

namespace BudgetControllerApi.Shared.Exceptions.Concrete
{
    public sealed class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException() : base("Invalid client request. The token has some invalid values.")
        {
        }
    }
}
