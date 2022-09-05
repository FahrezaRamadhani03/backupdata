// <copyright file="DesignTimeStorageContextFactoryBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Database.Abstract.Contracts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Database.Framework
{
    public abstract class DesignTimeStorageContextFactoryBase<T> : IDesignTimeDbContextFactory<T>
        where T : StorageContextBase
    {
        public static T StorageContext { get; set; }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            DesignTimeStorageContextFactoryBase<T>.StorageContext = serviceProvider.GetService<IStorageContext>() as T;
        }

        public T CreateDbContext(string[] args)
        {
            return DesignTimeStorageContextFactoryBase<T>.StorageContext;
        }
    }
}