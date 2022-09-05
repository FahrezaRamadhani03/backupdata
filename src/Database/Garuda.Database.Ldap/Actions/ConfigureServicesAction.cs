// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Configuration;
using Garuda.Database.Ldap.Configurations;
using Garuda.Database.Ldap.Contracts;
using Garuda.Database.Ldap.Services;
using Garuda.Infrastructure.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novell.Directory.Ldap;

namespace Garuda.Database.Ldap.Actions
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

            services.Configure<LdapLibraryConfig>(Configuration.GetSection("Ldap"));
            services.AddScoped<ILdapConnection, LdapConnection>();
            services.AddScoped<IAuthLibraryService, AuthLibraryService>();
        }
    }
}
