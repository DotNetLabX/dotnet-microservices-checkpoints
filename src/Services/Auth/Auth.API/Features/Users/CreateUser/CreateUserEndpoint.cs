using Articles.Abstractions.Enums;
using Auth.Domain.Persons;
using Auth.Domain.Users;
using Auth.Domain.Users.Events;
using Auth.Persistence;
using Auth.Persistence.Repositories;
using Blocks.Exceptions;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Features.Users.CreateUser;

[Authorize(Roles = Role.USERADMIN)]
[HttpPost("users")]
[Tags("Users")]
public class CreateUserEndpoint(PersonRepository _personRepository, AuthDbContext _dbContext, UserManager<User> _userManager)
    : Endpoint<CreateUserCommand, CreateUserResponse>
{
    public override async Task HandleAsync(CreateUserCommand command, CancellationToken ct)
    {
        var person = await _personRepository.GetByEmailAsync(command.Email);
        if (person?.User != null)
            throw new BadRequestException($"User with email {command.Email} already exists");

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

        if (person is null) // create new Person if not exists
            person = await CreatePersonAsync(command, ct);

        var user = Domain.Users.User.Create(command);

        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            var errorMessages = string.Join(" | ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
            throw new BadRequestException($"Unable to create user: {errorMessages}");
        }

        person.AssignUser(user);

        var ressetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);

        await _personRepository.SaveChangesAsync(ct);

        await PublishAsync(new UserCreated(user, ressetPasswordToken));
        await Send.OkAsync(new CreateUserResponse(command.Email, user.Id, ressetPasswordToken));
    }

    private async Task<Person> CreatePersonAsync(CreateUserCommand command, CancellationToken ct)
    {
        var person = Person.Create(command);
        await _personRepository.AddAsync(person);
        await _personRepository.SaveChangesAsync(ct);

        return person;
    }
}
