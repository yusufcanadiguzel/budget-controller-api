namespace BudgetControllerApi.Shared.Dtos.Product
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal UnitPrice { get; init; }
    }
}
