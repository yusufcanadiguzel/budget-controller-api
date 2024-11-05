using BudgetControllerApi.Entities.Contracts;

namespace BudgetControllerApi.Entities.Concrete
{
    public class ReceiptProduct : IEntity
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int ProductId { get; set; }

        public Receipt Receipt { get; set; }
        public Product Product { get; set; }
    }
}
