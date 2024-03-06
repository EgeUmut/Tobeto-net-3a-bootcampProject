using Business;
using Core.Exceptios.Extensions;
using DataAccess;
using Core;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolves.Autofac;
using Core.Extensions;
using Core.Utilities.IoC;




var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Sql Configuration and DI 
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();
builder.Services.AddCoreModule();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
ServiceTool.ServiceProvider = app.Services; //Service Tool for apsects and stuff

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleWare();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
