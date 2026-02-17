using Articles.Abstractions.Enums;

namespace Articles.Security;

public static class Role
{
    public const string EOF = nameof(UserRoleType.EOF);
    public const string REVED = nameof(UserRoleType.REVED);
    public const string CORAUT = nameof(UserRoleType.CORAUT);
    public const string AUT = nameof(UserRoleType.AUT);
    public const string USERADMIN = nameof(UserRoleType.USERADMIN);
}
