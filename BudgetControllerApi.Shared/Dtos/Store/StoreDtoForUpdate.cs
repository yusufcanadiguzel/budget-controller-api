using System.ComponentModel.DataAnnotations;

namespace BudgetControllerApi.Shared.Dtos.Store
{
    public record StoreDtoForUpdate : StoreDtoForManipulation
    {
        [Required(ErrorMessage = "Store id field is required.")]
        public int Id { get; init; }
    }
}
