using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Application.Services;
using Products.Infrastructure.Context;
using Products.Infrastructure.Interfaces;
using Products.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Crear variable para la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("Connection");
//Registrar servicio para la conexión
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddScoped<IManagerProduct, ManagerProduct>();

var app = builder.Build();

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
