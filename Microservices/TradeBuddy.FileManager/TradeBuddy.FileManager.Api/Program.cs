using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using TradeBuddy.FileManager.Infrastructure.Context;
using TradeBuddy.FileManager.Domain.Entities;
using TradeBuddy.FileManager.Application.Common.Interfaces;
using TradeBuddy.FileManager.Application.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Support for controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// تنظیمات MongoDB
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDbSettings:ConnectionString");
    return new MongoClient(connectionString);
});

builder.Services.AddScoped<IFileManagerService, FileManagerService>();
builder.Services.AddScoped<FileManagerDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Configuration
app.UseHttpsRedirection();
app.UseRouting(); // Routing setup

app.UseAuthorization(); // If you are using Authorization

// Map Controllers
app.MapControllers();

app.Run();
