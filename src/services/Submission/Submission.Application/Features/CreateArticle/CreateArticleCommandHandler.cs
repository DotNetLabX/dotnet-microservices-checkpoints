using Articles.Abstractions;
using MediatR;
using Submission.Domain.Entities;
using Submission.Persistence.Repositories;
using Blocks.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Articles.Abstractions.Enums;

namespace Submission.Application.Features.CreateArticle;

internal class CreateArticleCommandHandler(Repository<Journal> _journalRepository) : IRequestHandler<CreateArticleCommand,IdResponse>
{
    public async Task<IdResponse> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
    {
        var journal =  await _journalRepository.FindByIdOrThrowAsync(command.JournalId);

		var article = journal.CreateArticle(command.Title, command.ArticleType, command.Scope);

		await AssignCurrentUserAsAuthor(article, command);

        await _journalRepository.SaveChangesAsync(cancellationToken);

        return new IdResponse(article.Id);
	}

	private async Task AssignCurrentUserAsAuthor(Article article, CreateArticleCommand command)
	{
		var author = await _journalRepository.Context.Authors.SingleOrDefaultAsync(t => t.UserId == command.CreatedById);
		if (author is not null)
			article.AssignAuthor(author, [ContributionArea.OriginalDraft], isCorrespondingAuthor: true);
	}
}
