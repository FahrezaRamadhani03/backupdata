// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Configurations;
using Garuda.Infrastructure.Contracts;
using Garuda.Modules.Email.Configurations;
using Garuda.Modules.Email.Contracts;
using Garuda.Modules.Email.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Modules.Email.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public IConfiguration Configuration { get; set; }

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json");
            Configuration = builder.Build();

            services.Configure<EmailConfig>(Configuration.GetSection("EmailConfig"));
            services.Configure<AdditionalEmailConfiguration>(Configuration.GetSection("AdditionalEmailConfiguration"));
            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
