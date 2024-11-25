using Microsoft.EntityFrameworkCore;
using TradeBuddy.Business.Infrastructure.Context;
using TradeBuddy.Business.Application.Common.Interfaces;
using TradeBuddy.Business.Infrastructure.Messaging;
using TradeBuddy.Business.Application.Service;
using MediatR;
using System.Reflection;
using TradeBuddy.Business.Domain.Interfaces;
using TradeBuddy.Business.Infrastructure.Repositories;
using Nest;
using TradeBuddy.Business.Infrastructure.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext for BusinessService with SQL Server
var connectionString = builder.Configuration.GetConnectionString("BusinessService");
builder.Services.AddDbContext<BusinessDbContext>(options =>
    options.UseSqlServer(connectionString).UseLazyLoadingProxies());

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));

// ** Elasticsearch Configuration **
builder.Services.AddSingleton<IElasticClient>(sp =>
{
    var settings = new ConnectionSettings(new Uri(builder.Configuration["Elasticsearch:Uri"]))
        .DefaultIndex("business-index"); // ایندکس پیش‌فرض برای Elasticsearch
        // کامنت کردن بخش امنیت برای استفاده در سرور
        // .BasicAuthentication(
        //     builder.Configuration["Elasticsearch:Username"], 
        //     builder.Configuration["Elasticsearch:Password"]
        // );
    return new ElasticClient(settings);
});

// Register ElasticsearchIndexCreator
builder.Services.AddScoped<ElasticsearchIndexCreator>();

// Register Services
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<IMessagingService, RabbitMqService>();
builder.Services.AddTransient<IHostedService, MessageListenerService>();

// Register MediatR and handlers
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        Assembly.GetExecutingAssembly(),
        typeof(IBusinessService).Assembly,
        typeof(BusinessDbContext).Assembly
    );
});

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure HttpClient for external services
var reviewServiceUrl = builder.Configuration["ServiceUrls:ReviewService"];
builder.Services.AddHttpClient<IReviewServiceClient, ReviewServiceClient>(client =>
{
    client.BaseAddress = new Uri(reviewServiceUrl);
});

// Register Repositories for Elasticsearch (optional)
builder.Services.AddScoped(typeof(IElasticRepository<>), typeof(ElasticRepository<>));

// Build the application
var app = builder.Build();

// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Configuration
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Create Elasticsearch index if not exists
using (var scope = app.Services.CreateScope())
{
    var elasticsearchIndexCreator = scope.ServiceProvider.GetRequiredService<ElasticsearchIndexCreator>();
    await elasticsearchIndexCreator.CreateIndexIfNotExistsAsync();
}

app.Run();
