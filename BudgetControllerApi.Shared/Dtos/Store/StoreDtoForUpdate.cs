namespace BudgetControllerApi.Shared.Dtos.Store
{
    public record StoreDtoForUpdate
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public string TaxNumber { get; init; }
    }
}
