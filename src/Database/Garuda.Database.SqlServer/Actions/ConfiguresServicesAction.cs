// <copyright file="ConfiguresServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Database.SqlServer.Actions
{
    public class ConfiguresServicesAction : IConfigureServicesAction
    {
        public int Priority => 200;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(serviceProvider.GetService<IWebHostEnvironment>().ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            services.AddDbContext<StorageContext>(options =>
              options.UseSqlServer(configurationBuilder.Build().GetConnectionString("Connection")));

            services.AddScoped(typeof(IStorageContext), typeof(StorageContext));
        }
    }
}
