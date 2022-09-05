// <copyright file="IExtension.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Text;

namespace Garuda.Infrastructure.Contracts
{
    public interface IExtension
    {
        string Name { get; }

        string Description { get; }

        string Url { get; }

        string Version { get; }

        string Authors { get; }
    }
}
