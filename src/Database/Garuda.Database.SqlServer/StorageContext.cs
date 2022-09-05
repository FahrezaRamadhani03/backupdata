// <copyright file="StorageContext.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Database.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Garuda.Database.SqlServer
{
    public class StorageContext : StorageContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageContext"/> class.
        /// </summary>
        /// <param name="options">Based on Options</param>
        public StorageContext(IOptions<StorageContextOptions> options)
            : base(options)
        {
        }

        public StorageContext(DbContextOptions<StorageContextBase> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (string.IsNullOrEmpty(this.MigrationsAssembly))
            {
                optionsBuilder.UseSqlServer(this.ConnectionString, options => options.EnableRetryOnFailure());
            }
            else
            {
                optionsBuilder.UseSqlServer(
              this.ConnectionString,
              options =>
              {
                  options.MigrationsAssembly(this.MigrationsAssembly);
                  options.EnableRetryOnFailure();
              });
            }
        }
    }
}
