using BudgetControllerApi.Entities.Contracts;

namespace BudgetControllerApi.Entities.Concrete
{
    public class Receipt : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }
        // Store
        // Product
        // User

        public Receipt()
        {
            CreatedDate = DateTime.Now;
        }

        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
