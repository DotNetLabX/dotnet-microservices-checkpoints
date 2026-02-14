using Blocks.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.OM;
using StackExchange.Redis;

namespace Journals.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Database");

        services.AddSingleton(new RedisConnectionProvider(connectionString!));
        services.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(connectionString!.Replace("redis://", ""), options =>
                options.AbortOnConnectFail = false));

        services.AddSingleton<JournalDbContext>();
        services.AddScoped(typeof(Repository<>));

        return services;
    }
}
