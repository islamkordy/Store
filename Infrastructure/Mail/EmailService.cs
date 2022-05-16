using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Store.Application.Contract.Infrastructure;
using Store.Application.Models;

namespace Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings emailSetting { get; }

        public EmailService(IOptions<EmailSettings> emailSetting)
        {
            this.emailSetting = emailSetting.Value;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            var client = new SendGridClient(emailSetting.APIKey);

            var subject = email.Subject;
            var body = email.Body;
            var to = new EmailAddress(email.To);

            var from = new EmailAddress
            {
                Email = emailSetting.FromAddress,
                Name = emailSetting.FromName
            };

            var sendgridMessage = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var response = await client.SendEmailAsync(sendgridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}
