using API.Middleware;
using Application.Services;
using Application.Services.IProducts;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.DataAccess.Repositories.Base;
using Infrastructure.ExternalServices;
using Infrastructure.ExternalServices.IExtenalServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BusinessLabDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddScoped<IDiscountService, DiscountService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<LogResponseTime>();

app.MapControllers();

app.Run();
