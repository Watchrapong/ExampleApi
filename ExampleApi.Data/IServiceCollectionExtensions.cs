using AssetManagement.Core;
using AssetManagement.Core.Entities;

using Microsoft.Extensions.DependencyInjection;

namespace AssetManagement.Data;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddEnRepositories(this IServiceCollection services)
    {
        // register repositories with find all IEntity types
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