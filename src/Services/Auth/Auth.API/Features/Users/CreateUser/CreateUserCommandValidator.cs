using FastEndpoints;
using FluentValidation;

namespace Auth.API.Features.Users.CreateUser;

public class CreateUserCommandValidator : Validator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Email format is invalid.");

        RuleFor(c => c.UserRoles)
            .NotEmpty()
            .Must((c, roles) => AreUserRoleDatesValid(roles)).WithMessage("Invalid Role");

    }

    public static bool AreUserRoleDatesValid(IReadOnlyList<UserRoleDto> roles)
    {
        return roles.All(role =>
            // StartDate must be today or in the future otherwise we might have a security concern
            (!role.StartDate.HasValue || role.StartDate.Value.Date >= DateTime.UtcNow.Date) &&

            // ExpiringDate must be after StartDate (or today if StartDate is null)
            (!role.ExpiringDate.HasValue || (role.StartDate ?? DateTime.UtcNow).Date < role.ExpiringDate.Value.Date)
        );
    }
}
