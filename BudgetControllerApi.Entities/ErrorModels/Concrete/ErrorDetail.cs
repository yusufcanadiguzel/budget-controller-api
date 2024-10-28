using System.Text.Json;

namespace BudgetControllerApi.Entities.ErrorModels.Concrete
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
