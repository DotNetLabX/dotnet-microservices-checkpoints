using Articles.Abstractions;
using MediatR;
using Submission.Domain.Entities;
using Submission.Persistence.Repositories;

namespace Submission.Application.Features.CreateArticle;

internal class CreateArticleCommandHandler(Repository<Journal> _journalRepository) : IRequestHandler<CreateArticleCommand,IdResponse>
{
    public async Task<IdResponse> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
    {
        var journal =  await _journalRepository.FindByIdAsync(command.JournalId); //todo : throw NotFoundException if journal not found

        var article = journal.CreateArticle(command.Title, command.ArticleType, command.Scope);
        await _journalRepository.SaveChangesAsync(cancellationToken);

        return new IdResponse(article.Id);
		}
}
