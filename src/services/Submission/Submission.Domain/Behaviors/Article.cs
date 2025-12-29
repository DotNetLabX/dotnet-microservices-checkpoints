using Articles.Abstractions.Enums;
using Blocks.Exceptions;

namespace Submission.Domain.Entities;

public partial class Article
{

    public void AssignAuthor(Author author, HashSet<ContributionArea> contributionAreas, bool isCorrespondingAuthor)
    {
        var role = isCorrespondingAuthor ? UserRoleType.CORAUT : UserRoleType.AUT;

        if (Actors.Exists(a => a.PersonId == author.Id && a.Role == role))
            throw new DomainException($"Author {author.EmailAddress} is already assigned to the article");

        Actors.Add(new ArticleAuthor()
        {
            ContributionAreas = contributionAreas,
            Person = author,
            //PersonId = author.Id, 
            Role = role
        });

        // todo - create domain event
    }

}
