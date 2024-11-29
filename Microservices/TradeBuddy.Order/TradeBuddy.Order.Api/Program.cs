using Microsoft.EntityFrameworkCore;
using TradeBuddy.Order.Infrastructure.Context;
using MediatR; // MediatR for CQRS
using System.Reflection;
using TradeBuddy.Order.Domain.Interfaces;
using TradeBuddy.Order.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Support for controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext for BusinessService with SQL Server
var gngConnStr = builder.Configuration.GetConnectionString("OrderService");
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
//builder.Services.AddScoped<IReviewService, ReviewService>();
//builder.Services.AddScoped<IMessagingService, RabbitMqService>();

// Register MediatR and handlers
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        Assembly.GetExecutingAssembly(),
        typeof(OrderDbContext).Assembly
    );
});

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
