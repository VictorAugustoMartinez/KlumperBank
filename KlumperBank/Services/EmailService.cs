using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace KlumperBank.Services;

public static class EmailService
{
    public static bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Equipe pangolim-projects",
        string fromEmail = "pangolimprojects@gmail.com")
    {
        var smtpClient = new SmtpClient(Settings.Smtp.Host, Settings.Smtp.Port);

        smtpClient.Credentials = new NetworkCredential(Settings.Smtp.UserName, Settings.Smtp.Password);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        var mail = new MailMessage();

        mail.From = new MailAddress(fromEmail, fromName);
        mail.To.Add(new MailAddress(toEmail, toName));
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        try
        {
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}