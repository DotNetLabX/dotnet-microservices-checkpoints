namespace EmailService.Contracts;

public interface IEmailService
{
    Task<bool> SendEmailAsync(EmailMessage emailMessage, CancellationToken ct = default);
}

