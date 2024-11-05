namespace BudgetControllerApi.Shared.Dtos.Receipt
{
    public record ReceiptDtoForCreate : ReceiptDtoForManipulation
    {
        public int StoreId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
