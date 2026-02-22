using Auth.Grpc;
using Blocks.AspNetCore.Grpc;
using Blocks.Core;
using FileStorage.MongoGridFS;
using Journals.Grpc;

namespace Submission.API;

public static class DependencyInjection
{
	public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration config)
	{
		services
			.AddMemoryCache()
			.AddEndpointsApiExplorer()
			.AddSwaggerGen()
			;
		// Add API specific services here

		services.AddMongoFileStorage(config);


        //grpc Services
        var grpcOptions = config.GetSectionByTypeName<GrpcServicesOptions>();
        services.AddCodeFirstGrpcClient<IPersonService>(grpcOptions, "Person");
        services.AddCodeFirstGrpcClient<IJournalService>(grpcOptions, "Journal");

        return services;
	}
}
