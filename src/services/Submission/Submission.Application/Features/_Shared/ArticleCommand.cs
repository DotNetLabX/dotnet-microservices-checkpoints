using Blocks.Domain;
using Blocks.FluentValidation;
using System.Text.Json.Serialization;

namespace Submission.Application.Features.Shared;

public abstract record ArticleCommand<TActionType, TResponse> : IArticleAction<TActionType>, IRequest<TResponse>
    where TActionType : Enum
{
    [JsonIgnore]
    public int ArticleId { get; set; }

    public string? Comment { get; init; }

    [JsonIgnore]
    public abstract TActionType ActionType { get; }

    [JsonIgnore]
    public string Action => ActionType.ToString();

    [JsonIgnore]
    public DateTime CreatedOn => DateTime.UtcNow;

    [JsonIgnore]
    public int CreatedById { get; set; }
}

public abstract record ArticleCommand : ArticleCommand<ArticleActionType, IdResponse>;
public abstract class ArticleCommandValidator<TCommand> : AbstractValidator<TCommand>
    where TCommand : IArticleAction
{
    public ArticleCommandValidator()
    {
        RuleFor(command => command.ArticleId).GreaterThan(0)
            .WithMessageForInvalidId(nameof(ArticleCommand.ArticleId));
    }
}