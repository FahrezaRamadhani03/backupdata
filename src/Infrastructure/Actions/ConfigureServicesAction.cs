// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Configurations;
using Garuda.Infrastructure.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Infrastructure.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public IConfiguration Configuration { get; set; }

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json");
            Configuration = builder.Build();

            ////services.AddScoped<ApplicationSieveProcessor>();
            services.AddScoped<SieveProcessor>();
            services.Configure<UrlOptions>(Configuration.GetSection("BaseUrlApp"));
            //services.AddScoped<ISieveCustomFilterMethods, SieveCustomFilterMethods>();
            //services.AddScoped<ISieveCustomSortMethods, SieveCustomSortMethods>();
            //services.AddScoped<SieveProcessor>();
        }
    }
}
