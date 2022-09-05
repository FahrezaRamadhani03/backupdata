// <copyright file="IConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Infrastructure.Contracts
{
    public interface IConfigureServicesAction
    {
        int Priority { get; }

        void Execute(IServiceCollection services, IServiceProvider serviceProvider);
    }
}
