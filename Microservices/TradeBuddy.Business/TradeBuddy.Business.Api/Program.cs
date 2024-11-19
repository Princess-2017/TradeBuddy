using Microsoft.EntityFrameworkCore;
using TradeBuddy.Business.Infrastructure.Context;
using TradeBuddy.Business.Application.Common.Interfaces;
using TradeBuddy.Business.Infrastructure.Messaging;
using TradeBuddy.Business.Application.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext for BusinessService with SQL Server
var gngConnStr = builder.Configuration.GetConnectionString("BusinessService");
builder.Services.AddDbContext<BusinessDbContext>(options =>
    options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());

// اضافه کردن سرویس‌ها به DI
builder.Services.AddScoped<IBusinessService, BusinessService>();  // برای چرخه حیات درخواست
builder.Services.AddScoped<IMessagingService, RabbitMqService>();
// یا می‌توانید از Transient هم استفاده کنید.
builder.Services.AddTransient<IHostedService, MessageListenerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Here, you can add custom middlewares or other configurations

app.Run();
