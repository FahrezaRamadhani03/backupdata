// <copyright file="EmailSender.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Configurations;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Email.Actions;
using Garuda.Modules.Email.Configurations;
using Garuda.Modules.Email.Constants;
using Garuda.Modules.Email.Contracts;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace Garuda.Modules.Email.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _emailConfig = new EmailConfig();
        private readonly IConfiguration _config;
        private readonly AdditionalEmailConfiguration _additionalEmail = new AdditionalEmailConfiguration();
        private readonly IStorage _iStorage;
        private readonly UrlOptions _urlOptions = new UrlOptions();

        public EmailSender(
            IOptions<EmailConfig> emailConfig,
            IOptions<AdditionalEmailConfiguration> additionalEmail,
            IStorage iStorage,
            IOptions<UrlOptions> urlOptions,
            IConfiguration config)
        {
            _emailConfig = emailConfig.Value;
            _config = config;
            _additionalEmail = additionalEmail.Value;
            _iStorage = iStorage;
            _urlOptions = urlOptions.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string body, bool isHtml = false, BodyBuilder builder = null)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailConfig.SmtpName, _emailConfig.SmtpUsername));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = subject;

            if (builder != null)
            {
                builder.HtmlBody = body;
                message.Body = builder.ToMessageBody();
            }
            else
            {
                var textFormat = isHtml ? TextFormat.Html : TextFormat.Plain;
                message.Body = new TextPart(textFormat)
                {
                    Text = body,
                };
            }

            using (var client = new SmtpClient())
            {
                // Accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.SmtpPort, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

        public async Task SendEmailToQpbAdminAsync(string subject, string username, bool isHtml = false)
        {
            string body = string.Empty;
            var emails = new List<string>();
            var urlBase = _urlOptions.BaseUrlFE;
            var fromAddress = _emailConfig.SmtpUsername;
            var menus = await _iStorage.GetRepository<IMenuRepository>().GetData();
            var dataSlug = menus.Find(x => x.DisplayName == "User Management");
            var url = urlBase + dataSlug.Slug;
            var userGroupQpbs = await _iStorage.GetRepository<IUserGroupRepository>().GetQpbAdministrator();
            var userQpbs = userGroupQpbs.Select(x => x.User).ToList();
            if (string.Equals(_additionalEmail.EmailEnvironment.ToLower(), EmailEnvironmentConstant.DEVELOPMENT.ToLower()))
            {
                emails.AddRange(_additionalEmail.AdditionalEmails);
                var emailsData = userQpbs.Select(x => x.Email).ToArray();
                var emailsTo = string.Join(", ", emailsData);
                body = $"<html><body><p>This message was sent from development environment. On production environment, it would have been sent<br>From: {fromAddress}<br>To: {emailsTo}<br>Cc: - <br></p><p>Dear QPB Administrator,<br>Please review access request from &quot;{username}&quot; by following <a href=\"{url}\">this link</a><br><br>Thank you,<br>QPB Administrator</body></html>";
            }
            else
            {
                emails.AddRange(userQpbs.Select(x => x.Email).ToArray());
                body = $"<html><body><p>Dear QPB Administrator,<br>Please review access request from &quot;{username}&quot; by following <a href=\"{url}\">this link</a><br><br>Thank you,<br>QPB Administrator</body></html>";
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailConfig.SmtpName, _emailConfig.SmtpUsername));
            foreach (var email in emails)
            {
                message.To.Add(new MailboxAddress(email, email));
            }
            message.Subject = subject;

            var textFormat = isHtml ? TextFormat.Html : TextFormat.Plain;
            message.Body = new TextPart(textFormat)
            {
                Text = body,
            };

            using (var client = new SmtpClient())
            {
                // Accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.SmtpPort, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                //await client.AuthenticateAsync(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
