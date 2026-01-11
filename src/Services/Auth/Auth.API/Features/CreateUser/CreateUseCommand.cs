using Articles.Abstractions.Enums;
using Auth.Domain.Users;
using Auth.Domain.Users.Enums;

namespace Auth.API.Features.CreateUser;

public class CreateUserCommand : IUserUserCreationInfo
{
    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required Gender Gender { get; init; }

    public Honorific? Honorific { get; init; }

    public string? PhoneNumber { get; init; }
    public string? PictureUrl { get; init; }
    public string? CompanyName { get; init; }
    public string? Position { get; init; }
    public string? Affiliation { get; init; }

    public required IReadOnlyList<UserRoleDto> UserRoles { get; init; } = new List<UserRoleDto>();

    IReadOnlyList<IUserRole> IUserUserCreationInfo.UserRoles => UserRoles;
}

public record UserRoleDto(
    UserRoleType RoleType,
    DateTime? StartDate,
    DateTime? ExpiringDate
) : IUserRole;

public record CreateUserResponse(
    string Email,
    int UserId,
    string Token
);

