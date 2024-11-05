using System.ComponentModel.DataAnnotations;

namespace BudgetControllerApi.Shared.Dtos.Receipt
{
    public record ReceiptDtoForUpdate : ReceiptDtoForManipulation
    {
        [Required(ErrorMessage = "Receipt id is required")]
        public int Id { get; init; }
        [Required(ErrorMessage = "Store id is required")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Product ids are required")]
        public List<int> ProductIds { get; set; }
    }
}
