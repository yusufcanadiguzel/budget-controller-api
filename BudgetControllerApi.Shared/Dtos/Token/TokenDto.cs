namespace BudgetControllerApi.Shared.Dtos.Token
{
    public record TokenDto
    {
        public string AccessToken { get; init; }
        public string RefreshToken { get; init; }
    }
}
