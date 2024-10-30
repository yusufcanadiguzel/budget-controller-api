using Autofac;
using AutoMapper;
using BudgerControllerApi.WebApi.Utilities.Mapping.AutoMapper;
using BudgetControllerApi.Business.Concrete;
using BudgetControllerApi.Business.Contracts;
using BudgetControllerApi.Business.Logging.Contracts;
using BudgetControllerApi.Business.Logging.NLog;
using BudgetControllerApi.Business.Validation.FluentValidation;
using BudgetControllerApi.DataAccess.Concrete;
using BudgetControllerApi.DataAccess.Concrete.EFCore;
using BudgetControllerApi.DataAccess.Contracts;
using BudgetControllerApi.Presentation.ActionFilters;
using BudgetControllerApi.Shared.Dtos.Store;
using FluentValidation;

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

            // Action Filters Registration
            builder.RegisterType<ValidationFilterAttribute>().InstancePerLifetimeScope();
            builder.RegisterType<LogFilterAttribute>().SingleInstance();

            // Validator Configurations
            //builder.RegisterType<StoreDtoForCreateValidator>().As<IValidator<StoreDtoForManipulation>>();

            base.Load(builder);
        }
    }
}
