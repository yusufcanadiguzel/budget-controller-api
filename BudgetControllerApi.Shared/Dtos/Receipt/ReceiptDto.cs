using BudgetControllerApi.Shared.Dtos.Product;
using BudgetControllerApi.Shared.Dtos.ReceiptProduct;
using BudgetControllerApi.Shared.Dtos.Store;

namespace BudgetControllerApi.Shared.Dtos.Receipt
{
    public record ReceiptDto
    {
        public int Id { get; init; }
        public DateTime CreatedDate { get; init; }
        public decimal TotalPrice { get; init; }
        public StoreDto Store { get; set; }
        public List<ReceiptProductDto> ReceiptProducts { get; set; }
    }
}
