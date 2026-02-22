using Articles.Abstractions.Enums;
using Blocks.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Submission.Domain.Entities;
using Submission.Persistence.Repositories;

namespace Submission.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");
				
		services.AddDbContext<SubmissionDbContext>((provider, options) =>
		{

		});

		services.AddScoped(typeof(Repository<>));
		services.AddScoped(typeof(ArticleRepository));
		services.AddScoped(typeof(PersonRepository));

		services.AddScoped<CachedRepository<SubmissionDbContext, AssetTypeDefinition, AssetType>>();

        return services;
	}
}