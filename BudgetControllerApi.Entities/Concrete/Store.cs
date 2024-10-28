using BudgetControllerApi.Entities.Contracts;

namespace BudgetControllerApi.Entities.Concrete
{
    public class Store : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
    }
}
