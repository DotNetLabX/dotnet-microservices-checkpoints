using FastEndpoints;
using Auth.Domain.Users.Events;

namespace Auth.API.Features.CreateUser;

public class SendConfirmationEmailOnUserCreatedHandler
    : IEventHandler<UserCreated>
{
    public async Task HandleAsync(UserCreated eventModel, CancellationToken ct)
    {
    }
}
