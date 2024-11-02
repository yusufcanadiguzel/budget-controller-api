using Autofac;
using Autofac.Extensions.DependencyInjection;
using BudgerControllerApi.WebApi.DependencyResolvers.Autofac;
using BudgerControllerApi.WebApi.Extensions;
using BudgetControllerApi.Business.Logging.Contracts;
using Microsoft.AspNetCore.Mvc;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// NLog Configuration
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers(config =>
{
    // Content Negotiation
    config.RespectBrowserAcceptHeader = true;

    // Return Code 406
    config.ReturnHttpNotAcceptable = true;
})
// XML Content Output
.AddXmlDataContractSerializerFormatters()
.AddApplicationPart(typeof(BudgetControllerApi.Presentation.Concrete.AssemblyReference).Assembly)
.AddNewtonsoftJson();

// Configure Api Behavior About Validation
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection
builder.Services.ConfigureDbConnection(builder.Configuration);

// Dependency Resolver
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AfDependencyModule()));

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureCors();

// Identity Service Registration
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);

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

if(app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
