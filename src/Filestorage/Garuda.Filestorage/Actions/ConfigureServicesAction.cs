// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Reflection;
using Garuda.Filestorage.Contracts;
using Garuda.Infrastructure;
using Garuda.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garuda.Filestorage.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            Type type = ExtensionManager.GetImplementations<IFileStorageProvider>()?.FirstOrDefault(t => !t.GetTypeInfo().IsAbstract);

            if (type == null)
            {
                ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Garuda.Filestorage");

                logger.LogError("Implementation of Garuda.Filestorage not found");
                return;
            }

            services.AddScoped(typeof(IFileStorageProvider), type);
        }
    }
}
