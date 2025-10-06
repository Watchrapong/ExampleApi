using ExampleApi.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleApi.Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();

        return services;
    }
}