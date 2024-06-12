using ETicaretAPI.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ETicaretAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], "Mini E-Ticaret", System.Text.Encoding.UTF8);
            mail.Priority = MailPriority.Normal;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }

            using (SmtpClient smtp = new())
            {
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(_configuration["Mail:Port"]);
                smtp.Host = _configuration["Mail:Host"];
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                await smtp.SendMailAsync(mail);
            }
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Hello!<br><br>A user requested a password reset for this e-mail address,<br>If you didn't request a password change, please ignore this e-mail.<br><br><strong>To change your password please click <a target=\"_blank\" href=\"");
            mail.AppendLine(_configuration["Urls:AngularClientUrl"]);
            mail.AppendLine("/password-update/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">here</a>...</strong><br>Thanks,<br>Mini|E-Ticaret");

            await SendMailAsync(to, "Password Reset Request", mail.ToString());
        }
    }
}
