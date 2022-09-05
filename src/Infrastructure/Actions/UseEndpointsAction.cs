// <copyright file="UseEndpointsAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Garuda.Infrastructure.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garuda.Infrastructure.Actions
{
    public class UseEndpointsAction : IConfigureAction
    {
        public int Priority => 11000;

        public void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider)
        {
            applicationBuilder.UseEndpoints(
            endpointRouteBuilder =>
            {
                foreach (IUseEndpointsAction action in ExtensionManager.GetInstances<IUseEndpointsAction>().OrderBy(a => a.Priority))
                {
                    ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Garuda.Infrastructure");

                    logger.LogInformation("Executing UseEndpoints action '{0}'", action.GetType().FullName);
                    action.Execute(endpointRouteBuilder, serviceProvider);
                }
            });
        }
    }
}