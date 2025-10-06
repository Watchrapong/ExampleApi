using ExampleApi.Core;
using ExampleApi.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleApi.Data;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        var entityTypes = typeof(IEntity).Assembly.GetTypes()
            .Where(t => t.IsClass)
            .Where(t => t.GetInterfaces().Contains(typeof(IEntity)))
            .ToList();

        foreach (var entityType in entityTypes)
        {
            var repositoryType = typeof(Repository<>).MakeGenericType(entityType);
            services.AddScoped(typeof(IRepository<>).MakeGenericType(entityType), repositoryType);
        }

        return services;
    }
}