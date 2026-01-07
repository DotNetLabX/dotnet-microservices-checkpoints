using Blocks.FluentValidation;

namespace Submission.Application.Features.CreateArticle;

public record CreateArticleCommand(int JournalId, string Title, string Scope, ArticleType ArticleType) :
    ArticleCommand
{
    public override ArticleActionType ActionType => ArticleActionType.CreateArticle;
}

public class CreateArticleCommandValiator : ArticleCommandValidator<CreateArticleCommand>
{
    public CreateArticleCommandValiator()
    {
        RuleFor(x => x.Title)
            .NotEmptyWithMessage(nameof(CreateArticleCommand.Title));
        RuleFor(x => x.Scope)
            .NotEmptyWithMessage(nameof(CreateArticleCommand.Scope));

        RuleFor(x => x.JournalId)
            .GreaterThan(0).WithMessageForInvalidId(nameof(CreateArticleCommand.JournalId));

    }
}
