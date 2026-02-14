using Articles.Security;
using Blocks.Core;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using Blocks.Mapster;
using Blocks.AspNetCore.Grpc;
using Auth.Grpc;

namespace Journals.Api;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApiOptions(this IServiceCollection services, IConfiguration config)
    {
        //use it for configuring options
        services
            .AddAndValidateOptions<JwtOptions>(config)
            .Configure<JsonOptions>(opt =>
            {
                opt.SerializerOptions.PropertyNameCaseInsensitive = true;
                opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        return services;
    }

    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddFastEndpoints()
            .SwaggerDocument()              // FastEndpoints swagger
            .AddJwtAuthentication(config)
            .AddMapster()
            .AddAuthorization();

        // Grpc clients
        var grpcOptions = config.GetSectionByTypeName<GrpcServicesOptions>();
        services.AddCodeFirstGrpcClient<IPersonService>(grpcOptions, "Person");

        return services;
    }
}
