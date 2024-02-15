using Business.Abstracts;
using Business.Concretes;
using DataAccess;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;

var builder = WebApplication.CreateBuilder(args);


//deneme DI
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Sql Configuration
builder.Services.AddDataAccessServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
