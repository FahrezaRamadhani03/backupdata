// <copyright file="AddStaticFilesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Garuda.Infrastructure.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Garuda.Infrastructure.Actions
{
    public class AddStaticFilesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<IWebHostEnvironment>().WebRootFileProvider = this.CreateCompositeFileProvider(serviceProvider);
        }

        private IFileProvider CreateCompositeFileProvider(IServiceProvider serviceProvider)
        {
            IFileProvider[] fileProviders = new IFileProvider[]
            {
              serviceProvider.GetService<IWebHostEnvironment>().WebRootFileProvider,
            };

            return new CompositeFileProvider(fileProviders.Concat(ExtensionManager.Assemblies.Select(a => new EmbeddedFileProvider(a, a.GetName().Name))));
        }
    }
}