// <copyright file="IEmailSender.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Contracts;
using MimeKit;

namespace Garuda.Modules.Email.Contracts
{
    /// <summary>
    /// Email sender provider Contract
    /// </summary>
    public interface IEmailSender : IServiceRepository
    {
        /// <summary>
        /// Send Email Contract
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="isHtml"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string message, bool isHtml = false, BodyBuilder builder = null);

        /// <summary>
        /// Send Email Contract
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="username"></param>
        /// <param name="isHtml"></param>
        /// <returns></returns>
        Task SendEmailToQpbAdminAsync(string subject, string username, bool isHtml = false);
    }
}
