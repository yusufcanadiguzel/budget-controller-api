using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BudgerControllerApi.WebApi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<BudgetControllerDbContext>
    {
        // DbContext Config
        public BudgetControllerDbContext CreateDbContext(string[] args)
        {
            // Configuration
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            // DbContext Options
            var builder = new DbContextOptionsBuilder<BudgetControllerDbContext>().UseSqlServer(configuration.GetConnectionString("DefaultConnection"), project => project.MigrationsAssembly("BudgetControllerApi.WebApi"));

            return new BudgetControllerDbContext(builder.Options);
        }
    }
}
