using Garuda.Database.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Database.PostgreSql
{
    public class StorageContext : StorageContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageContext"/> class.
        /// </summary>
        /// <param name="options">Based on Options</param>
        public StorageContext(IOptions<StorageContextOptions> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (string.IsNullOrEmpty(this.MigrationsAssembly))
            {
                optionsBuilder.UseNpgsql(this.ConnectionString, options => options.EnableRetryOnFailure());
            }
            else
            {
                optionsBuilder.UseNpgsql(
                     this.ConnectionString,
                     options =>
                     {
                         options.MigrationsAssembly(this.MigrationsAssembly);
                         options.EnableRetryOnFailure();
                     }
               );
            }
        }
    }
}
