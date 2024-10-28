using Autofac;
using BudgetControllerApi.Business.Concrete;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Business.Logging.Contracts;
using BudgetControllerApi.Business.Logging.NLog;
using BudgetControllerApi.DataAccess.Concrete;
using BudgetControllerApi.DataAccess.Concrete.EFCore;
using BudgetControllerApi.DataAccess.Contracts;

namespace BudgerControllerApi.WebApi.DependencyResolvers.Autofac
{
    public class AfDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Repository Manager Configuration
            builder.RegisterType<RepositoryManager>().As<IRepositoryService>();

            // Store Configurations
            builder.RegisterType<EfStoreRepository>().As<IStoreRepository>();
            builder.RegisterType<StoreManager>().As<IStoreService>();

            // Service Configuration
            builder.RegisterType<ServiceManager>().As<IServiceManager>();

            // NLog Configuration
            builder.RegisterType<NlLoggerManager>().As<ILoggerService>();

            base.Load(builder);
        }
    }
}
