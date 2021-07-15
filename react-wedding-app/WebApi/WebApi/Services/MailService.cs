using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebApi.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
    
        public MailService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task SendMailAsync(string toEmail, string subject, string content)
        {
            var apiKey = this._configuration["SendGrid:Key"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(this._configuration["SendGrid:Email"]);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }

        public bool IsValidEmail(string email)
        {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
    }
}