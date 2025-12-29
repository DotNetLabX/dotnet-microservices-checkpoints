using Blocks.MediatR.Behaviours;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Submission.Application.Features.CreateArticle;
using System.Reflection;

namespace Submission.Application;

public static class DependencyInjection
{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
				services
						.AddValidatorsFromAssemblyContaining<CreateArticleCommandValiator>()
						.AddMediatR(config => 
						{
								config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
								config.AddOpenBehavior(typeof(ValidationBehavior<,>));

						});
				return services;
		}
}
