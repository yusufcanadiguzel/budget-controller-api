using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Presentation.ActionFilters;
using BudgetControllerApi.Shared.Dtos.Token;
using BudgetControllerApi.Shared.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControllerApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserDtoForRegistration userDtoForRegistration)
        {
            var result = await _serviceManager.AuthenticationService.RegisterUser(userDtoForRegistration);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Created();
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserDtoForAuthentication userDtoForAuthentication)
        {
            var result = await _serviceManager.AuthenticationService.ValidateUser(userDtoForAuthentication);

            if(!result)
                return Unauthorized();

            var tokenDto = await _serviceManager.AuthenticationService.CreateToken(populateExpireTime: true);

            return Ok(tokenDto);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _serviceManager.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }
    }
}
