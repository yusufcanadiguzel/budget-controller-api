using AutoMapper;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Business.Logging.Contracts;
using BudgetControllerApi.Entities.Concrete;
using BudgetControllerApi.Shared.Dtos.Token;
using BudgetControllerApi.Shared.Dtos.User;
using BudgetControllerApi.Shared.Exceptions.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BudgetControllerApi.Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _loggerService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        private User? _user;

        public AuthenticationManager(ILoggerService loggerService, IConfiguration configuration, IMapper mapper, UserManager<User> userManager)
        {
            _loggerService = loggerService;
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<TokenDto> CreateToken(bool populateExpireTime)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;

            if (populateExpireTime)
                _user.RefreshTokenExpireTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        public async Task<IdentityResult> RegisterUser(UserDtoForRegistration userDtoForRegistration)
        {
            var user = _mapper.Map<User>(userDtoForRegistration);

            var result = await _userManager.CreateAsync(user, userDtoForRegistration.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userDtoForRegistration.Roles);

            return result;
        }

        public async Task<bool> ValidateUser(UserDtoForAuthentication userDtoForAuthentication)
        {
            _user = await _userManager.FindByNameAsync(userDtoForAuthentication.UserName);

            var result = (_user is not null) && (await _userManager.CheckPasswordAsync(_user, userDtoForAuthentication.Password));

            if (!result)
                _loggerService.LogWarning($"{nameof(ValidateUser)} : Authentication failed. Wrong username or password.");


            return result;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

            var symmetricKey = new SymmetricSecurityKey(key);

            return new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["ValidIssuer"],
                audience: jwtSettings["ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["Expires"])),
                signingCredentials: signingCredentials
                );

            return tokenOptions; 
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(randomNumber);

                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPricipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings["ValidIssuer"],
                ValidateAudience = true,
                ValidAudience = jwtSettings["ValidAudience"],
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if ((jwtSecurityToken is null) || (!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var pricipal = GetPricipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(pricipal.Identity.Name);

            if ((user is null) || (user.RefreshToken != tokenDto.RefreshToken) || (user.RefreshTokenExpireTime <= DateTime.Now))
                throw new RefreshTokenBadRequestException();

            _user = user;

            return await CreateToken(populateExpireTime: false);
        }
    }
}
