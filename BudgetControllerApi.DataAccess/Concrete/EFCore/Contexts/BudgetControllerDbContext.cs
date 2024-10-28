using BudgetControllerApi.DataAccess.Concrete.EFCore.Config;
using BudgetControllerApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts
{
    public class BudgetControllerDbContext : DbContext
    {
        public BudgetControllerDbContext(DbContextOptions<BudgetControllerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Store> Stores => Set<Store>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
