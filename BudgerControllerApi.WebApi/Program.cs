using Autofac;
using Autofac.Extensions.DependencyInjection;
using BudgerControllerApi.WebApi.DependencyResolvers.Autofac;
using BudgerControllerApi.WebApi.Extensions;
using BudgetControllerApi.Business.Logging.Contracts;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// NLog Configuration
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers().AddApplicationPart(typeof(BudgetControllerApi.Presentation.Concrete.AssemblyReference).Assembly).AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection
builder.Services.ConfigureDbConnection(builder.Configuration);

// Dependency Resolver
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AfDependencyModule()));

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Adding Custom Exception Extension
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
