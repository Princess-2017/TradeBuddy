using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq; // Ensure you include this for LINQ methods
using TradeBuddy.Customer.Domain.Interfaces;
using TradeBuddy.Customer.Application.Common.Interfaces;
using TradeBuddy.Customer.Infrastructure.Messaging;

namespace TradeBuddy.Customer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IMessagingService, RabbitMqService>();
            // Automatically register all repositories
            RegisterRepositories(services);
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
                    var entityType = genericArguments[0]; // Rename to entityType
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
