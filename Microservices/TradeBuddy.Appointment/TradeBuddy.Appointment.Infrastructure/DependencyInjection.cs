using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;
using TradeBuddy.Appointment.Application.Common.Interfaces;
using TradeBuddy.Appointment.Domain.Interfaces;
using TradeBuddy.Appointment.Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Ensure this is included
using TradeBuddy.Appointment.Infrastructure.Context;

namespace TradeBuddy.Appointment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) // Add IConfiguration here
        {
            services.AddSingleton<IMessagingService, RabbitMqService>();
            // Automatically register all repositories
            RegisterRepositories(services);

            services.AddDbContext<AppointmentDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppointmentService"))); // Use configuration instead of Configuration

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            // Get all types in the current assembly
            var assembly = Assembly.GetExecutingAssembly();
            var repositoryType = typeof(IRepository<,>);

            // Find all entity types implementing IRepository
            var repositoryTypes = assembly.GetTypes()
                .Where(t => t.BaseType != null &&
                            t.BaseType.IsGenericType &&
                            repositoryType.IsAssignableFrom(t.BaseType));

            foreach (var repository in repositoryTypes)
            {
                var genericArguments = repository.BaseType.GetGenericArguments();
                if (genericArguments.Length == 2)
                {
                    var entityType = genericArguments[0];
                    var keyType = genericArguments[1];

                    // Create the generic type of the repository interface
                    var repositoryInterface = repositoryType.MakeGenericType(entityType, keyType);

                    // Register the service
                    services.AddScoped(repositoryInterface, repository);
                }
            }
        }
    }
}
