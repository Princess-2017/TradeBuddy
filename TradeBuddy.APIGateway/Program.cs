using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن ocelot.json به تنظیمات برنامه
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// فعال‌سازی لاگ
builder.Logging.AddConsole();
builder.Services.AddControllers();
builder.Services.AddOcelot();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.UseOcelot();

app.Run();
