// <copyright file="UseConfiguration.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Contracts;
using Garuda.Modules.Hangfire.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Garuda.Modules.Hangfire.Actions
{
    public class UseConfiguration : IConfigureAction
    {
        public int Priority => 1100;

        public void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider)
        {
            applicationBuilder.UseHangfire();

            applicationBuilder.InitializeHangfireJobs();
        }
    }
}
