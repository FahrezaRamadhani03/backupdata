// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using DinkToPdf;
using DinkToPdf.Contracts;
using Garuda.Infrastructure.Contracts;
using Garuda.Modules.Common.Services.Repositories;
using Garuda.Modules.ProjectManagement.Helper;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Mapper;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Garuda.Modules.ProjectManagement.Sieve;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Actions
{
    public class ConfigureServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddAutoMapper(typeof(CommonProfiles));
            services.AddScoped<IProjectDetailServices, ProjectDetailServices>();
            services.AddScoped<IDevelopmentRoleService, DevelopmentRoleServices>();
            services.AddScoped<IStatusServices, StatusServices>();
            services.AddScoped<ITechnologyServices, TechnologyServices>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IDevelopmentInfoServices, DevelopmentInfoServices>();
            services.AddScoped<IDevelopmentScrumServices, DevelopmentScrumServices>();
            services.AddScoped<IDevelopmentHolidayServices, DevelopmentHolidayServices>();
            services.AddScoped<ITaxServices, TaxServices>();
            services.AddScoped<IPaymentTermServices, PaymentTermServices>();
            services.AddScoped<ILevelServices, LevelServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IProjectDevelopmentTeamServices, ProjectDevelopmentTeamServices>();
            services.AddScoped<IProposalServices, ProposalServices>();
            services.AddScoped<IProjectFileServices, ProjectFileServices>();
            services.AddScoped<IBankServices, BankServices>();
            services.AddScoped<IInvoiceServices, InvoiceServices>();
            services.AddScoped<ITimelineServices, TimelineServices>();
            services.AddScoped<ITimelineServices, TimelineServices>();
            services.AddScoped<IDashboardServices, DashboardServices>();
            services.AddScoped<ApplicationSieveProcessor>();
            services.AddScoped<SieveProcessor>();
            services.AddScoped<ISieveCustomFilterMethods, SieveCustomFilterMethods>();
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
            services.AddScoped<IRazorRendererHelper, RazorRendererHelper>();
            services.AddScoped<IAddressServices, AddressServices>();
            services.AddScoped<IProjectExpensesServices, ProjectExpensesServices>();
            services.AddScoped<IFileChecker, FileChecker>();
            services.AddScoped<IProfitProjectServices, ProfitProjectServices>();
            services.AddScoped<IBudgetServices, BudgetServices>();
            services.AddScoped<INotificationServices, NotificationServices>();
        }
    }
}
