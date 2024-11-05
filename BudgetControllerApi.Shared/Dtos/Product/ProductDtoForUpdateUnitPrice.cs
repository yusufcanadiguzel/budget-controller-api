namespace BudgetControllerApi.Shared.Dtos.Product
{
    public record ProductDtoForUpdateUnitPrice
    {
        public int Id { get; init; }
        public decimal UnitPrice { get; init; }
    }
}
