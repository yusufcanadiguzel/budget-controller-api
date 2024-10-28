using BudgetControllerApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore.Config
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                new Store { Id = 1, Name = "BİM Birleşik Mağazalar A.Ş.", Address = "İstanbul", TaxNumber = "1750051846" }
            );
        }
    }
}
