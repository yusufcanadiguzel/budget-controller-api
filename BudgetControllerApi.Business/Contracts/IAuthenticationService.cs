using BudgetControllerApi.Shared.Dtos.Token;
using BudgetControllerApi.Shared.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace BudgetControllerApi.Business.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserDtoForRegistration userDtoForRegistration);
        Task<bool> ValidateUser(UserDtoForAuthentication userDtoForAuthentication);
        Task<TokenDto> CreateToken(bool populateExpireTime);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
