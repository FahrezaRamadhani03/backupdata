// <copyright file="StorageContextBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Garuda.Database.Framework
{
    // public abstract class StorageContextBase : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>, IStorageContext
    public abstract class StorageContextBase : DbContext, IStorageContext
    {
        public string ConnectionString { get; private set; }

        public string ConnectionStringBridging { get; private set; }

        public string MigrationsAssembly { get; private set; }

        public StorageContextBase(DbContextOptions<StorageContextBase> options)
           : base(options)
        {
        }

        public StorageContextBase(IOptions<StorageContextOptions> options)
        {
            this.ConnectionString = options.Value.ConnectionString;
            this.MigrationsAssembly = options.Value.MigrationsAssembly;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.RegisterEntities(modelBuilder);
        }
    }
}