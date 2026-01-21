using Auth.Domain.Users.Enums;
using Auth.Domain.Users.ValueObjects;
using Blocks.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Users;

public partial class User : IdentityUser<int>, IEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public required Gender Gender { get; set; }

    public HonorificTitle? Honorific { get; set; }

    public ProfessionalProfile? ProfessionalProfile { get; set; }

    public string? PictureUrl { get; set; }

    public DateTime RegistrationDate { get; init; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }

    private List<UserRole> _userRoles = new ();
    public virtual IReadOnlyList<UserRole> UserRoles => _userRoles;

    private List<RefreshToken> _refreshTokens = new ();
    public virtual IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens;
}