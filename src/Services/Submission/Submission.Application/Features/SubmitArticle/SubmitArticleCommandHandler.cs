namespace Submission.Application.Features.SubmitArticle;

public class SubmitArticleCommandHandler(ArticleRepository _articleRepository)
    : IRequestHandler<SubmitArticleCommand, IdResponse>
{
    public async Task<IdResponse> Handle(SubmitArticleCommand command, CancellationToken ct)
    {
        var article = await _articleRepository.FindByIdOrThrowAsync(command.ArticleId);

        article.Submit(command);

        await _articleRepository.SaveChangesAsync(ct);

        return new IdResponse(article.Id);
    }
}
