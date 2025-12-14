namespace Submission.API.Endpoints;

public static class EndpointRegistration
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        CreateArticleEndpoint.Map(app);

        return app;
    }
}
