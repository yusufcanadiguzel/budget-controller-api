using BudgetControllerApi.Entities.Contracts;

namespace BudgetControllerApi.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public List<ReceiptProduct> ReceiptProducts { get; set; }
    }
}
