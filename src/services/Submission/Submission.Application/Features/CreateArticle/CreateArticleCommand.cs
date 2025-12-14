using Articles.Abstractions;
using Articles.Abstractions.Enums;
using FluentValidation;
using MediatR;

namespace Submission.Application.Features.CreateArticle;

public record CreateArticleCommand (int JournalId, string Title, string Scope, ArticleType ArticleType) : IRequest<IdResponse>
{
}

public class CreateArticleCommandValiator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValiator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be null");
        RuleFor(x => x.Scope)
            .NotEmpty().WithMessage("Scope cannot be null");

        RuleFor(x => x.JournalId).GreaterThan(0);

    }
}
