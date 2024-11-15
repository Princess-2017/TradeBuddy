using TradeBuddy.Auth.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// افزودن خدمات به کانتینر
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data Base Context Service
var gngConnStr = builder.Configuration.GetConnectionString("AuthService");
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());

var app = builder.Build();

// پیکربندی پایپ‌لاین درخواست HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
