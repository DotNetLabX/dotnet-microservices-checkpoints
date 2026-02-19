
using Auth.Grpc;
using Grpc.Core;

namespace Submission.Application.Features.ApproveArticle;

public class ApproveArticleCommandHandler(ArticleRepository _articleRepository, PersonRepository _personRepository, IPersonService _personClient)
    : IRequestHandler<ApproveArticleCommand, IdResponse>
{
    public async Task<IdResponse> Handle(ApproveArticleCommand command, CancellationToken ct)
    {
        var article = await _articleRepository.FindByIdOrThrowAsync(command.ArticleId);

        Person editor = await GetOrCreatePersonByUserId(command.CreatedById, ct);

        article.Approve(editor, command);

        await _articleRepository.SaveChangesAsync(ct);

        return new IdResponse(article.Id);
    }

    private async Task<Person> GetOrCreatePersonByUserId(int userId, CancellationToken ct)
    {
        var person = await _personRepository.GetByUserIdAsync(userId);
        if (person is null)
        {
            var response = await _personClient.GetPersonByUserIdAsync(new GetPersonByUserIdRequest { UserId = userId }, new CallOptions(cancellationToken: ct));

            person = Person.Create(response.PersonInfo);
            await _personRepository.AddAsync(person, ct);
        }

        return person;
    }
}
