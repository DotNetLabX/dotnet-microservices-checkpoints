using Microsoft.Extensions.Options;
using Flurl;
using Blocks.AspNetCore;
using EmailService.Contracts;
using Auth.Domain.Users.Events;
using Auth.Domain.Users;
using FastEndpoints;

namespace Auth.API.Features.Users.CreateUser;

public class SendConfirmationEmailOnUserCreatedHandler
    (IEmailService emailService, IHttpContextAccessor httpContextAccessor, IOptions<EmailOptions> emailOptions)
    : IEventHandler<UserCreated>
{
    public async Task HandleAsync(UserCreated eventModel, CancellationToken ct)
    {
        var url = httpContextAccessor.HttpContext?.Request.BaseUrl()
            .AppendPathSegment("set-first-password")
            .SetQueryParams(new { eventModel.RessetPasswordToken });

        var emailMessage = BuildConfirmationEmail(eventModel.User, url, emailOptions.Value.EmailFromAddress);

        await emailService.SendEmailAsync(emailMessage);
    }

    public EmailMessage BuildConfirmationEmail(User user, string resetLink, string fromEmailAddress)
    {
        const string ConfirmationEmail =
            "Dear {0},<br/>An account has been created for you.<br/>Please set your password using the following URL: <br/>{1}";

        return new EmailMessage(
            "Your Account Has Been Created – Set Your Password",
            new Content(ContentType.Html, string.Format(ConfirmationEmail, user.Person.FullName, resetLink)),
            new EmailAddress("articles", fromEmailAddress),
            new List<EmailAddress> { new EmailAddress(user.Person.FullName, user.Email!) }
            );
    }
}
