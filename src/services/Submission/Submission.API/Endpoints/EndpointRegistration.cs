using Submission.Api.Endpoints;

namespace Submission.API.Endpoints;

public static class EndpointRegistration
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        CreateArticleEndpoint.Map(app);
        AssignAuthorEndpoint.Map(app);
        CreateAndAssignAuthorEndpoint.Map(app);
        SubmitArticleEndpoint.Map(app);
        ApproveArticleEndpoint.Map(app);
        UploadManuscriptFileEndpoint.Map(app);

        return app;
    }
}
