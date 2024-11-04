using System.ComponentModel.DataAnnotations;

namespace BudgetControllerApi.Shared.Dtos.Receipt
{
    public record ReceiptDtoForUpdate : ReceiptDtoForManipulation
    {
        [Required(ErrorMessage = "Receipt id is required")]
        public int Id { get; init; }
    }
}
