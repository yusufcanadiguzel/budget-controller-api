using BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BudgerControllerApi.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BudgetControllerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BudgerControllerApi.WebApi"));
            });
        }
    }
}
