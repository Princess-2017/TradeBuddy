using TradeBuddy.Auth.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TradeBuddy.Auth.Infrastructure.Configurations;
using TradeBuddy.Auth.Application.Common.Interfaces;
using TradeBuddy.Auth.Application.Service;

//var builder = WebApplication.CreateBuilder(args);

//// افزودن خدمات به کانتینر
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddIdentityServer()
//        .AddInMemoryClients(AuthConfig.GetClients());

//builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder => builder.WithOrigins("https://kasbiyar.com")
//                          .AllowAnyHeader()
//                          .AllowAnyMethod());
//});



//// Configure DbContext for BusinessService with SQL Server
//var connectionString = builder.Configuration.GetConnectionString("AuthService");
//builder.Services.AddDbContext<AuthDbContext>(options =>
//    options.UseSqlServer(connectionString).UseLazyLoadingProxies());


//var app = builder.Build();


//app.UseSwagger();
//app.UseSwaggerUI();


//app.UseHttpsRedirection();

//app.Run();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext for BusinessService with SQL Server
var connectionString = builder.Configuration.GetConnectionString("AuthService");
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString).UseLazyLoadingProxies());


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

app.Run();
