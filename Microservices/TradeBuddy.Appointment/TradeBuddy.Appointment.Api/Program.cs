using Microsoft.EntityFrameworkCore;
using TradeBuddy.Appointment.Application.Common.Interfaces;
using TradeBuddy.Appointment.Application.Services;
using TradeBuddy.Appointment.Infrastructure.Context;
using TradeBuddy.Appointment.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add controllers to the service collection
builder.Services.AddControllers();  // این خط را اضافه کنید

// Data Base Context Service
var gngConnStr = builder.Configuration.GetConnectionString("AppointmentService");
builder.Services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(gngConnStr).UseLazyLoadingProxies());
// Add other necessary services like RabbitMQ or others
// Example: Registering Messaging Service
builder.Services.AddSingleton<IMessagingService, RabbitMqService>();
// یا می‌توانید از Transient هم استفاده کنید.
builder.Services.AddTransient<IHostedService, MessageListenerService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Enable routing and define endpoints
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Ensure controllers are mapped
});

app.Run();
