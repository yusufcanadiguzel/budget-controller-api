namespace BudgetControllerApi.Shared.Dtos.ReceiptProduct
{
    public record ReceiptProductDtoForCreate
    {
        public int ReceiptId { get; init; }
        public int ProductId { get; init; }
    }
}
