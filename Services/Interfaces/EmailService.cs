﻿using FitnessPro.ViewModel;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

using MailKit.Net.Smtp;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPro.Services.Interfaces
{
    public class EmailService : IFitnessEmailSender
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        
        
        public Task sendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }


        public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(_mailSettings.Mail));
            email.Subject = subject;

            var builder = new BodyBuilder()

            {
                HtmlBody=htmlMessage
            };
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);

            await smtp.SendAsync(email);

            smtp.Disconnect(true);

            
        }
    }
}
