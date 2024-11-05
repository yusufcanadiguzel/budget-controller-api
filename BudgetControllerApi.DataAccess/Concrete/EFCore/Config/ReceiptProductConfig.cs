using BudgetControllerApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore.Config
{
    public class ReceiptProductConfig : IEntityTypeConfiguration<ReceiptProduct>
    {
        public void Configure(EntityTypeBuilder<ReceiptProduct> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Receipt
            builder
                .HasOne(x => x.Receipt)
                .WithMany(r => r.ReceiptProducts)
                .HasForeignKey(x => x.ReceiptId);

            // Product
            builder
                .HasOne(x => x.Product)
                .WithMany(p => p.ReceiptProducts)
                .HasForeignKey(x => x.ProductId);

            builder.HasData(
                new ReceiptProduct
                {
                    Id = 1,
                    ReceiptId = 2,
                    ProductId = 1,
                }
                );
        }
    }
}
