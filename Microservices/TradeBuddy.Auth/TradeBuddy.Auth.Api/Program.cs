using TradeBuddy.Auth.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TradeBuddy.Auth.Infrastructure.Configurations;
using TradeBuddy.Auth.Application.Common.Interfaces;
using TradeBuddy.Auth.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// افزودن خدمات به کانتینر
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer()
        .AddInMemoryClients(AuthConfig.GetClients());

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://kasbiyar.com")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});


// Data Base Context Service
var gngConnStr = builder.Configuration.GetConnectionString("AuthService");
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();
