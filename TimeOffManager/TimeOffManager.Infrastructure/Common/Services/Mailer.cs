namespace TimeOffManager.Infrastructure.Common.Services
{
    using Application.Common.Contracts;
    using Application.Common.Entities;
    using Common.Entities;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using MimeKit;
    using System;
    using System.Threading.Tasks;
    using SmtpClient = MailKit.Net.Smtp.SmtpClient;

    public class Mailer : IMailer
    {
        private readonly SmtpSettings smtpSettings;
        private readonly IWebHostEnvironment env;

        public Mailer(
            IOptions<SmtpSettings> smtpSettings, 
            IWebHostEnvironment env
            )
        {
            this.smtpSettings = smtpSettings.Value;
            this.env = env;
        }

        public async Task SendEmailAsync(MailOutputModel mail)
        {
            if (!env.IsDevelopment())
                await this.SendEmail(mail);
        }

        private async Task SendEmail(MailOutputModel mail)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress(smtpSettings.SenderName, smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress(mail.Name, mail.Email));
                message.Subject = mail.Subject;
                message.Body = new TextPart("html")
                {
                    Text = mail.Body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (env.IsDevelopment())
                    {
                        await client.ConnectAsync(smtpSettings.Server, smtpSettings.Port, true);
                    }
                    else
                    {
                        await client.ConnectAsync(smtpSettings.Server);
                    }

                    await client.AuthenticateAsync(smtpSettings.Username, smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}