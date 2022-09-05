// <copyright file="HangfireServiceCollectionExtensions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Modules.Hangfire.Configurations;
using Garuda.Modules.Hangfire.Contracts;
using Garuda.Modules.Hangfire.Services;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Modules.Hangfire.Extensions
{
    /// <summary>
    /// Extensions for Hangfire Service.
    /// </summary>
    public static class HangfireServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Hangfire Service extensions.
        /// </summary>
        public static IServiceCollection AddHangfireService(this IServiceCollection services) => services.AddHangfireService(null);

        /// <summary>
        /// Adds Hangfire contrib extensions and configures Hangfire with the specified <see cref="IGlobalConfiguration"/> action.
        /// </summary>
        public static IServiceCollection AddHangfireService(this IServiceCollection services, Action<IGlobalConfiguration> configAction)
        {
            services.AddSingleton(services);

            services.AddHangfire(c =>
            {
                configAction?.Invoke(c);
            });

            services.AddTransient<IBackgroundJobManager, BackgroundJobManager>();
            services.AddSingleton<BackgroundJobCollection>();

            return services;
        }
    }
}
