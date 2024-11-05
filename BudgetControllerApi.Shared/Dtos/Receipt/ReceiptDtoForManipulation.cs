using System.ComponentModel.DataAnnotations;

namespace BudgetControllerApi.Shared.Dtos.Receipt
{
    public abstract record ReceiptDtoForManipulation
    {
        [Required(ErrorMessage = "Total price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be a positive number with up to two decimal places.")]
        public decimal TotalPrice { get; init; }
    }
}
