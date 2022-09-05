// <copyright file="AccountServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Ldap.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Auth.Constants;
using Garuda.Modules.Auth.Models.Contracts;
using Garuda.Modules.Auth.Models.Datas;
using Garuda.Modules.Auth.Services.Contracts;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Garuda.Modules.Email.Configurations;
using Garuda.Modules.Email.Contracts;
using Garuda.Modules.Email.Models.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Utils;

namespace Garuda.Modules.Auth.Services.Repositories
{
    public class AccountServices : IAccountServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _logger;
        private readonly IJwtFactory _jwt;
        private readonly IEmailSender _emailSender;

        private readonly IConfiguration _emailConfig;

        public AccountServices(
            IStorage iStorage,
            ILogger<AccountServices> logger,
            IJwtFactory jwt,
            IEmailSender emailSender,
            IConfiguration emailConfig,
            IOptions<EmailConfig> config)
        {
            _iStorage = iStorage;
            _logger = logger;
            _jwt = jwt;
            _emailSender = emailSender;
            _emailConfig = emailConfig;
        }

        public async Task<MessageDto> RequestResetPassword(ReqResetPasswordRequests model)
        {
            try
            {
                _logger.LogInformation("Getting user data from database..");
                var user = await _iStorage.GetRepository<IUserRepository>().GetData(model.EmailOrUser);
                var verification = await _iStorage.GetRepository<IResetPasswordVerificationRepository>().GetAllData();

                if (user != null)
                {
                    if (user.IsActive == false)
                    {
                        throw ErrorConstant.INACTIVE_USER;
                    }

                    string code = string.Empty;
                    bool isValid = false;
                    while (!isValid)
                    {
                        code = RandomString(6);
                        if (!verification.Any(x => x.Code == code))
                        {
                            isValid = true;
                        }
                    }
                    
                    var resetVerification = new ResetPasswordVerification()
                    {
                        Code = code,
                        ExpirationTime = DateTime.Now.AddMinutes(30),
                        Email = user.Email,
                    };

                    var template = await _iStorage.GetRepository<ITemplateEmailRepository>().GetData(ConstantApp.RequestResetPasswordTemplate);
                    var logo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Image" + Path.DirectorySeparatorChar + "logo-gik.png";
                    var resetLink = _emailConfig.GetValue<string>("WebUrl") + "/reset-password/" + code;
                    var builder = new BodyBuilder();
                    var image = builder.LinkedResources.Add(logo);
                    image.ContentId = MimeUtils.GenerateMessageId();

                    var email_body = template.Body.Replace("#-link-#", resetLink).Replace("#-logo-#", "cid:" + image.ContentId).Replace("#-fullname-#", user.Fullname).Replace("#-footer-#", template.Footer);
                    
                    await _emailSender.SendEmailAsync(user.Email, "Request Reset Password", email_body, true, builder);
                    await _iStorage.GetRepository<IResetPasswordVerificationRepository>().AddOrUpdate(resetVerification);
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "Email has been sent", null, model);
                }
                else
                {
                    throw ErrorConstant.INVALID_USER;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<MessageDto> ResetPassword(ResetPasswordRequests model)
        {
            try
            {
                _logger.LogInformation("Getting reset password verification data from database..");
                var resetPasswordVerification = await _iStorage.GetRepository<IResetPasswordVerificationRepository>().GetData(model.Code);

                if (resetPasswordVerification == null || DateTime.Now > resetPasswordVerification.ExpirationTime)
                {
                    return new MessageDto("Reset password link has expired");
                }

                _logger.LogInformation("Getting user data from database..");
                var user = await _iStorage.GetRepository<IUserRepository>().GetData(resetPasswordVerification.Email);

                if (user != null)
                {
                    if (user.IsActive == false)
                    {
                        throw ErrorConstant.INACTIVE_USER;
                    }

                    var updatedUser = new User()
                    {
                        Id = user.Id,
                        Password = EncryptPassword.Encrypt(model.Password),
                    };

                    var updatedPassVerification = new ResetPasswordVerification()
                    {
                        Id = resetPasswordVerification.Id,
                        ExpirationTime = DateTime.Now.AddDays(-1)
                    };

                    model.UserName = user.Username;
                    await _iStorage.GetRepository<IUserRepository>().UpdatePassword(updatedUser);
                    await _iStorage.GetRepository<IResetPasswordVerificationRepository>().AddOrUpdate(updatedPassVerification);
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.SUCCESS, "Updated", "Your password has been successfully updated", null, model);
                }
                else
                {
                    throw ErrorConstant.INVALID_USER;
                }
            }
            catch
            {
                throw;
            }
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}