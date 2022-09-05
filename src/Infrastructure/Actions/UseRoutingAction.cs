// <copyright file="UseRoutingAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Builder;

namespace Garuda.Infrastructure.Actions
{
    /// <summary>
    /// Implements the <see cref="IConfigureAction">IConfigureAction</see> interface and registers the
    /// routing middleware inside a web application's request pipeline.
    /// </summary>
    public class UseRoutingAction : IConfigureAction
    {
        public int Priority => 10000;

        public void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider)
        {
            applicationBuilder.UseRouting();
        }
    }
}