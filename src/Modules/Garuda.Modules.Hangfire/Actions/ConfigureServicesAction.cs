// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Contracts;
using Garuda.Modules.Hangfire.Configurations;
using Garuda.Modules.Hangfire.Extensions;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Modules.Hangfire.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            var sp = services.BuildServiceProvider();
            var configuration = sp.GetRequiredService<IConfiguration>();
            services.AddHangfireService(config =>
            {
                config.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"));
            });

            // overwrite HangfireBaseOptions
            services.PostConfigure<HangfireConfigureOptions>(o =>
            {
                o.Dasbhoard.AuthorizationCallback = httpContext =>
                {
                    var user = httpContext.User;
                    return user.Identity.IsAuthenticated && user.IsInRole("admin");
                };
            });
        }
    }
}
