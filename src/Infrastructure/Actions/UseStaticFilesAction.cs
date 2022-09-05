// <copyright file="UseStaticFilesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Garuda.Infrastructure.Actions
{
    public class UseStaticFilesAction : IConfigureAction
    {
        public int Priority => 1000;

        public void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider)
        {
            IOptions<StaticFileOptions> options = serviceProvider.GetService<IOptions<StaticFileOptions>>();

            applicationBuilder.UseStaticFiles(options?.Value);
        }
    }
}