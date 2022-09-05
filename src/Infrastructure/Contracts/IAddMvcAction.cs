// <copyright file="IAddMvcAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Infrastructure.Contracts
{
    public interface IAddMvcAction
    {
        int Priority { get; }

        void Execute(IMvcBuilder mvcBuilder, IServiceProvider serviceProvider);
    }
}