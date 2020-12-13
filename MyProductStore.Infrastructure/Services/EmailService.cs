using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using MyProductStore.Core.Interfaces;
using MyProductStore.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace MyProductStore.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendAsync(string subject, string html, string to, string from = null)
        {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(from ?? _emailConfiguration.SmtpUsername));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = html };

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, SecureSocketOptions.Auto);
                await client.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
