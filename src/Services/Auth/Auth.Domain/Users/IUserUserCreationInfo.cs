using Articles.Abstractions;
using Articles.Abstractions.Enums;

namespace Auth.Domain.Users;

public interface IUserUserCreationInfo : IPersonCreationInfo
{
    string? PhoneNumber { get; }
    IReadOnlyList<IUserRole> UserRoles { get; }
}

public interface IUserRole
{
    DateTime? ExpiringDate { get; }
    UserRoleType RoleType { get; }
    DateTime? StartDate { get; }
}