using SendGrid.Helpers.Mail;
using SendGrid;

namespace KlumperBank.Services;

public static class EmailService
{

    public static async Task Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Equipe pangolim-projects",
        string fromEmail = "pangolimprojects@gmail.com")
    {
        var client = new SendGridClient(Settings.Smtp.UserName);
        var from = new EmailAddress(fromEmail, fromName);
        var to = new EmailAddress(toEmail, toName);

        var htmlContent = subject + " " + body;
        var msg = MailHelper.CreateSingleEmail(from, to, subject, body, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }
}