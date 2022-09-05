// <copyright file="ExtensionBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Contracts;

namespace Garuda.Infrastructure.Models
{
    public abstract class ExtensionBase : IExtension
    {
        public virtual string Name => GetType().FullName;

        public virtual string Description => null;

        public virtual string Url => null;

        public virtual string Version => null;

        public virtual string Authors => null;
    }
}
