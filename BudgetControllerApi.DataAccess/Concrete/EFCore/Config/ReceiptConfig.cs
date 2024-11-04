using BudgetControllerApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore.Config
{
    public class ReceiptConfig : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasData(
                new Receipt { Id = 2, StoreId = 1, TotalPrice = 138 }
            );
        }
    }
}
