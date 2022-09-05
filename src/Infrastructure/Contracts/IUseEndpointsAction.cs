// <copyright file="IUseEndpointsAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Routing;

namespace Garuda.Infrastructure.Contracts
{
    public interface IUseEndpointsAction
    {
        int Priority { get; }

        void Execute(IEndpointRouteBuilder endpointRouteBuilder, IServiceProvider serviceProvider);
    }
}