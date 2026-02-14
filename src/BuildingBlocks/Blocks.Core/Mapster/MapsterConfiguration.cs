using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blocks.Mapster;

public static class MapsterConfiguration
{
    public static IServiceCollection AddMapster(this IServiceCollection services, Assembly? assembly = null)
    {
        if (assembly is null)
            assembly = Assembly.GetCallingAssembly()!;

        TypeAdapterConfig.GlobalSettings.Scan(assembly);
        return services;
    }
}
