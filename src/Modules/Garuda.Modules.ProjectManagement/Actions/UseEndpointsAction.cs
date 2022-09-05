// <copyright file="UseEndpointsAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Garuda.Modules.ProjectManagement.Actions
{
    public class UseEndpointsAction : IUseEndpointsAction
    {
        public int Priority => 1000;

        public void Execute(IEndpointRouteBuilder endpointRouteBuilder, IServiceProvider serviceProvider)
        {
            endpointRouteBuilder.MapControllerRoute(name: "Employee", pattern: "{controller}/{action}", defaults: new { controller = "Employee", action = "GetEmployee" });
        }
    }
}
