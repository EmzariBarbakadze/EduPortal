using EduPortal.Models.HelperClasses;
using EduPortal.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace EduPortal.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly IErrorLogger _logger;

        public EmailService(IOptions<EmailSettings> settings, IErrorLogger logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }


        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {

            if (string.IsNullOrWhiteSpace(toEmail))
            {
                await _logger.LogServiceErrorAsync(
                    "1000",
                    "toEmail is null or empty in SendEmailAsync method - EmailService",
                    "Service",
                    "SendEmailAsync"
                );

                throw new ArgumentException("Recipient email address cannot be null or empty.", nameof(toEmail));
            }

            using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}
