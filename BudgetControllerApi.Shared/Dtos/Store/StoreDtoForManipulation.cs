using System.ComponentModel.DataAnnotations;

namespace BudgetControllerApi.Shared.Dtos.Store
{
    public abstract record StoreDtoForManipulation
    {
        [Required(ErrorMessage = "Store name field is required.")]
        [MinLength(3, ErrorMessage = "Store name field cannot be shorter than 3 characters.")]
        [MaxLength(ErrorMessage = "Store name field cannot be longer than 50 characters.")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Store address field is required.")]
        [Range(3, 250, ErrorMessage = "Store address field is must be between 3 and 250 characters long.")]
        public string Address { get; init; }

        [Required(ErrorMessage = "Store tax number field is required.")]
        [Length(10, 10, ErrorMessage = "Store tax number must be 10 characters")]
        public string TaxNumber { get; init; }
    }
}
