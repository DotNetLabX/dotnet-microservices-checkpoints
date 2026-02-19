using Auth.Grpc;

namespace Submission.Domain.Entities;

public partial class Person
{
    public static Person Create(PersonInfo userInfo)
    {
        return new Person
        {
            Id = userInfo.Id,
            UserId = userInfo.Id,
            Email = EmailAddress.Create(userInfo.Email),
            FirstName = userInfo.FirstName,
            LastName = userInfo.LastName,
            Affiliation = userInfo.ProfessionalProfile!.Affiliation,
        };
    }
}
