using Microsoft.EntityFrameworkCore;
using TradeBuddy.Payment.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data Base Context Service
var gngConnStr = builder.Configuration.GetConnectionString("PaymentService");
builder.Services.AddDbContext<PaymentDbContext>(options => options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();
