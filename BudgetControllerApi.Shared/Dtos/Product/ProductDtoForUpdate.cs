namespace BudgetControllerApi.Shared.Dtos.Product
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        public int Id { get; init; }
    }
}
