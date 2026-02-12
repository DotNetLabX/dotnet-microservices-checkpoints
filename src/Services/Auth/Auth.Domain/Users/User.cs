using Auth.Domain.Persons;
using Blocks.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Users;

public partial class User : IdentityUser<int>, IEntity
{
    public DateTime RegistrationDate { get; init; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; init; } = null!;

    private List<UserRole> _userRoles = new ();
    public virtual IReadOnlyList<UserRole> UserRoles => _userRoles;

    private List<RefreshToken> _refreshTokens = new ();
    public virtual IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens;
}