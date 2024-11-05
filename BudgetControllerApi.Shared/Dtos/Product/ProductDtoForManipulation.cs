using System.ComponentModel.DataAnnotations;

namespace BudgetControllerApi.Shared.Dtos.Product
{
    public abstract record ProductDtoForManipulation
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name field cannot be shorter than 3 characters.")]
        [MaxLength(ErrorMessage = "Name field cannot be longer than 50 characters.")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be higher than 0.")]
        public decimal UnitPrice { get; init; }
    }
}
