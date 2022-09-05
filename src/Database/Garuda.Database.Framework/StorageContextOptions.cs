// <copyright file="StorageContextOptions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Database.Framework
{
    public class StorageContextOptions
    {
        public string ConnectionString { get; set; }

        public string ConnectionStringBridging { get; set; }

        public string MigrationsAssembly { get; set; }
    }
}