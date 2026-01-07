using Submission.Domain.ValueObjects;

namespace Submission.Domain.Entities;

public partial class Author
{
    public static new Author Create(string email, string firstName, string lastName, string? title, string affiliation)
    {
        var author = new Author
        {
            EmailAddress = EmailAddress.Create(email),
            FirstName = firstName,
            LastName = lastName,
            Title = title,
            Affiliation = affiliation,
        };

        // todo add AuhtorCreated domain event
        return author;
    }
}
