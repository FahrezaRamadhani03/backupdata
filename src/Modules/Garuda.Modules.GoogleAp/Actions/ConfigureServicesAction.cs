// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Configurations;
using Garuda.Infrastructure.Contracts;
using Garuda.Modules.GoogleAp.Configurations;
using Garuda.Modules.GoogleAp.Services.Contracts;
using Garuda.Modules.GoogleAp.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Modules.GoogleAp.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public IConfiguration Configuration { get; set; }

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            this.Configuration = builder.Build();

            services.Configure<CalendarAPIConfig>(this.Configuration.GetSection("CalendarAPI"));
            services.AddScoped<IGoogleCalendarSender, GoogleCalendarSender>();
        }
    }
}
