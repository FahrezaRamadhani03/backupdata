// <copyright file="IConfigureAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Builder;

namespace Garuda.Infrastructure.Contracts
{
    public interface IConfigureAction
    {
        int Priority { get; }

        void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider);
    }
}
