// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Contracts;
using Garuda.Modules.Common.Mapper;
using Garuda.Modules.Common.Services.Contracts;
using Garuda.Modules.Common.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Modules.Common.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddAutoMapper(typeof(CommonProfiles));
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IMenuServices, MenuServices>();
            services.AddScoped<IGroupServices, GroupServices>();
            services.AddScoped<IUnitServices, UnitServices>();
            services.AddScoped<IUserUnitServices, UserUnitServices>();
        }
    }
}
