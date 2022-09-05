// <copyright file="ServiceCollectionExtensions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Garuda.Extension.Contracts;
using Garuda.Infrastructure;
using Garuda.Infrastructure.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garuda.Extension.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGarudaCore(this IServiceCollection services)
        {
            services.AddGarudaCore(null);
        }

        public static void AddGarudaCore(this IServiceCollection services, string extensionsPath)
        {
            services.AddGarudaCore(extensionsPath, false, new DefaultAssemblyProvider(services.BuildServiceProvider()));
        }

        public static void AddGarudaCore(this IServiceCollection services, string extensionsPath, bool includingSubpaths)
        {
            services.AddGarudaCore(extensionsPath, includingSubpaths, new DefaultAssemblyProvider(services.BuildServiceProvider()));
        }

        public static void AddGarudaCore(this IServiceCollection services, string extensionsPath, IAssemblyProvider assemblyProvider)
        {
            services.AddGarudaCore(extensionsPath, false, assemblyProvider);
        }

        public static void AddGarudaCore(this IServiceCollection services, string extensionsPath, bool includingSubpaths, IAssemblyProvider assemblyProvider)
        {
            ServiceCollectionExtensions.DiscoverAssemblies(assemblyProvider, extensionsPath, includingSubpaths);

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Garuda.Extension");
            foreach (IConfigureServicesAction action in ExtensionManager.GetInstances<IConfigureServicesAction>().OrderBy(a => a.Priority))
            {
                logger.LogInformation("Executing ConfigureServices action '{0}'", action.GetType().FullName);
                action.Execute(services, serviceProvider);
                serviceProvider = services.BuildServiceProvider();
            }
        }

        private static void DiscoverAssemblies(IAssemblyProvider assemblyProvider, string extensionsPath, bool includingSubpaths)
        {
            ExtensionManager.SetAssemblies(assemblyProvider.GetAssemblies(extensionsPath, includingSubpaths));
        }
    }
}