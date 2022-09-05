// <copyright file="StorageContextExtensions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Database.Framework.Extensions
{
    public static class StorageContextExtensions
    {
        public static void RegisterEntities(this IStorageContext storageContext, ModelBuilder modelBuilder)
        {
            foreach (IEntityRegister entityRegistrar in ExtensionManager.GetInstances<IEntityRegister>())
            {
                entityRegistrar.RegisterEntities(modelBuilder);
            }
        }
    }
}