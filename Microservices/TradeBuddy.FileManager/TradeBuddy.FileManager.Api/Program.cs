using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using TradeBuddy.FileManager.Infrastructure.Context;
using TradeBuddy.FileManager.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// تنظیمات سرویس‌ها
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// تنظیمات MongoDB
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDbSettings:ConnectionString");
    return new MongoClient(connectionString);
});

builder.Services.AddScoped<FileManagerDbContext>();

var app = builder.Build();

// تنظیمات Swagger
app.UseSwagger();
app.UseSwaggerUI();

// تنظیمات HTTP
app.UseHttpsRedirection();
app.UseRouting();

app.Run();
