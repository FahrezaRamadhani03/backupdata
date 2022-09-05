// <copyright file="AddMvcAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Reflection;
using Garuda.Infrastructure.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garuda.Infrastructure.Actions
{
    public class AddMvcAction : IConfigureServicesAction
    {
        public int Priority => 10000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            IMvcBuilder mvcBuilder = services.AddMvc();

            foreach (Assembly assembly in ExtensionManager.Assemblies)
            {
                mvcBuilder.AddApplicationPart(assembly);
            }

            foreach (IAddMvcAction action in ExtensionManager.GetInstances<IAddMvcAction>().OrderBy(a => a.Priority))
            {
                ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Garuda.Infrastructure");

                logger.LogInformation("Executing AddMvc action '{0}'", action.GetType().FullName);
                action.Execute(mvcBuilder, serviceProvider);
            }
        }
    }
}