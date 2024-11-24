using Microsoft.EntityFrameworkCore;
using TradeBuddy.Business.Infrastructure.Context;
using TradeBuddy.Business.Application.Common.Interfaces;
using TradeBuddy.Business.Infrastructure.Messaging;
using TradeBuddy.Business.Application.Service;
using MediatR; // MediatR for CQRS
using System.Reflection;
using TradeBuddy.Business.Domain.Interfaces;
using TradeBuddy.Business.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Support for controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext for BusinessService with SQL Server
var gngConnStr = builder.Configuration.GetConnectionString("BusinessService");
builder.Services.AddDbContext<BusinessDbContext>(options =>
    options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));

// Add Scoped and Transient Services
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<IMessagingService, RabbitMqService>();
builder.Services.AddTransient<IHostedService, MessageListenerService>();

// HttpClient configuration (assuming ReviewService is external)
var reviewServiceUrl = builder.Configuration["ServiceUrls:ReviewService"];
builder.Services.AddHttpClient<IReviewServiceClient, ReviewServiceClient>(client =>
{
    client.BaseAddress = new Uri(reviewServiceUrl);
});

// Register MediatR and handlers
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        Assembly.GetExecutingAssembly(),
        typeof(IBusinessService).Assembly,
        typeof(BusinessDbContext).Assembly
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
