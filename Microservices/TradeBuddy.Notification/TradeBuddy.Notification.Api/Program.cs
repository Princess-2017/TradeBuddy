using Microsoft.EntityFrameworkCore;
using TradeBuddy.Notification.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data Base Context Service
var gngConnStr = builder.Configuration.GetConnectionString("NotificationService");
builder.Services.AddDbContext<NotificationDbContext>(options => options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();
