using FileStorage.MongoGridFS;

namespace Submission.API;

public static class DependencyInjection
{
	public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddMemoryCache()
			.AddEndpointsApiExplorer()
			.AddSwaggerGen()
			;
		// Add API specific services here

		services.AddMongoFileStorage(configuration);

		return services;
	}
}
