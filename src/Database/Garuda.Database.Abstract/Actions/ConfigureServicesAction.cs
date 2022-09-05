// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure;
using Garuda.Infrastructure.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garuda.Database.Abstract.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 200;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            Type type = ExtensionManager.GetImplementations<IStorage>()?.FirstOrDefault(t => !t.GetTypeInfo().IsAbstract);

            if (type == null)
            {
                ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Garuda.Abstract");

                logger.LogError("Implementation of Garuda.Abstract not found");
                return;
            }

            services.AddScoped(typeof(IStorage), type);
        }
    }
}
