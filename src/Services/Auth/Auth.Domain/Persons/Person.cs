using Articles.Abstractions.Enums;
using Auth.Domain.Persons.ValueObjects;
using Auth.Domain.Users;
using Blocks.Domain.Entities;

namespace Auth.Domain.Persons;

public partial class Person : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public required Gender Gender { get; set; }

    public HonorificTitle? Honorific { get; set; }

    public required EmailAddress Email{ get; set; }

    public ProfessionalProfile? ProfessionalProfile { get; set; }

    public string? PictureUrl { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }
}
