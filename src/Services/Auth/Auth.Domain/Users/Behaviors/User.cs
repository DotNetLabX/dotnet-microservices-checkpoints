using Auth.Domain.Persons.ValueObjects;
using Blocks.Core;

namespace Auth.Domain.Users;

public partial class User
{
    public static User Create(IUserUserCreationInfo userInfo)
    {
        if (userInfo.UserRoles.IsNullOrEmpty())
            throw new ArgumentException("User must have at least one role.", nameof(userInfo.UserRoles));

        var user = new User
        {
            UserName = userInfo.Email,
            Email = userInfo.Email,
            PhoneNumber = userInfo.PhoneNumber,
            _userRoles = userInfo.UserRoles.Select(r => UserRole.Create(r)).ToList(),
        };

        ///user.AddDomainEvent(new UserCreated(this));

        return user;
    }

    public void AddRefreshToken(RefreshToken refreshToken)
    {
        if (refreshToken is null)
            throw new ArgumentNullException(nameof(refreshToken));
        _refreshTokens.Add(refreshToken);
    }
}
