using Articles.Abstractions;
using Articles.Abstractions.Enums;
using Blocks.Domain;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace Submission.Application.Features.CreateArticle;

public record CreateArticleCommand (int JournalId, string Title, string Scope, ArticleType ArticleType) : IAuditableAction, IRequest<IdResponse>
{
    [JsonIgnore]
    public DateTime CreatedOn => DateTime.UtcNow;
    [JsonIgnore]
    public int CreatedById { get; set; }

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
