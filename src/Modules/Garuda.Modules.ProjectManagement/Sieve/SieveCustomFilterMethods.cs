// <copyright file="SieveCustomFilterMethods.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Linq;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Project;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Sieve
{
    public class SieveCustomFilterMethods : ISieveCustomFilterMethods
    {
        public IQueryable<ProjectSieveDto> Type(IQueryable<ProjectSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => (s.ClientId == null && values[0].ToLower() == "internal")
                    || (s.ClientId != null && values[0].ToLower() == "external"));
            }

            return result;
        }

        public IQueryable<TimelineProjectDto> Type(IQueryable<TimelineProjectDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => (s.ClientId == null && values[0].ToLower() == "internal")
                    || (s.ClientId != null && values[0].ToLower() == "external"));
            }

            return result;
        }

        public IQueryable<TimelineProjectDto> ProjectName(IQueryable<TimelineProjectDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => values.Contains(s.ProjectName));
            }

            return result;
        }

        public IQueryable<TimelineProjectDto> DevelopmentPeriod(IQueryable<TimelineProjectDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                var listPeriod = values[0].Split(';').ToList();
                result = source.Where(s => (s.StartDate >= System.DateTime.Parse(listPeriod[0]) &&
                s.EndDate <= System.DateTime.Parse(listPeriod[1])) || s.Parent == null);
            }

            return result;
        }

        public IQueryable<TimelineProjectDto> StatusTimeline(IQueryable<TimelineProjectDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => values.Contains(s.Status) || s.Parent == null);
            }

            return result;
        }

        public IQueryable<EmployeeSieveDto> DeveloperName(IQueryable<EmployeeSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.Fullname == values[0]);
            }

            return result;
        }

        public IQueryable<EmployeeSieveDto> Type(IQueryable<EmployeeSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => (s.ClientId == null && values[0].ToLower() == "internal")
                      || (s.ClientId != null && values[0].ToLower() == "external"));
            }

            return result;
        }

        public IQueryable<EmployeeSieveDto> ProjectName(IQueryable<EmployeeSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.ProjectDevelopmentTeams.Any(u => values.Contains(u.ProjectDetail.Name)));
            }

            return result;
        }

        public IQueryable<EmployeeSieveDto> ProjectStatus(IQueryable<EmployeeSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.ProjectDevelopmentTeams.Any(u => values.Contains(u.ProjectDetail.Status)));
            }

            return result;
        }

        public IQueryable<EmployeeSieveDto> ClientName(IQueryable<EmployeeSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.ProjectDevelopmentTeams.Any(u => values.Contains(u.ProjectDetail.Client.Name)));
            }

            return result;
        }

        public IQueryable<EmployeeSieveDto> DeveloperRole(IQueryable<EmployeeSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.ProjectDevelopmentTeams.Any(u => u.DevelopmentTeamRoles.Any(u => values.Contains(u.DeveloperRole.DevelopmentRole.Name))));
            }

            return result;
        }

        public IQueryable<EmployeeSieveDto> ProjectPeriode(IQueryable<EmployeeSieveDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.ProjectDevelopmentTeams.Any(u => u.ProjectDetail.DevelopmentScrums.Any(u => u.DevelopmentScrumSprints.Any(u => u.SprintStart.Date >= System.DateTime.Parse(values[0]) || u.SprintEnd.Date <= System.DateTime.Parse(values[0])))));
            }

            return result;
        }

        public IQueryable<ProjectListResponses> DevelopmentPeriod(IQueryable<ProjectListResponses> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                var listPeriod = values[0].Split(';').ToList();
                result = source.Where(s => s.DevelopmentStart >= System.DateTime.Parse(listPeriod[0]) || s.DevelopmentEnd <= System.DateTime.Parse(listPeriod[1]));
            }

            return result;
        }

        public IQueryable<ProjectListResponses> MaintenancePeriod(IQueryable<ProjectListResponses> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                var listPeriod = values[0].Split(';').ToList();
                result = source.Where(s => s.MaintenanceStart >= System.DateTime.Parse(listPeriod[0]) || s.MaintenanceEnd <= System.DateTime.Parse(listPeriod[1]));
            }

            return result;
        }

        public IQueryable<ExpenseDto> BudgetType(IQueryable<ExpenseDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.BudgetActivity != null && s.BudgetActivity.BudgetType != null &&
                                           s.BudgetActivity.BudgetType.TypeName != null &&
                                           s.BudgetActivity.BudgetType.TypeName.ToLower().Contains(values[0].ToLower()));
            }

            return result;
        }

        public IQueryable<ExpenseDto> BudgetActivity(IQueryable<ExpenseDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.BudgetActivity != null && s.BudgetActivity.BudgetType != null &&
                                           s.BudgetActivity.Name != null &&
                                           s.BudgetActivity.Name.ToLower().Contains(values[0].ToLower()));
            }

            return result;
        }

        public IQueryable<BudgetActivityDto> BudgetType(IQueryable<BudgetActivityDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.BudgetType != null && s.BudgetType.TypeName != null &&
                                           s.BudgetType.TypeName.ToLower().Contains(values[0].ToLower()));
            }

            return result;
        }

        public IQueryable<ProjectInvoiceResponses> Status(IQueryable<ProjectInvoiceResponses> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                result = source.Where(s => s.Invoices.Any(u => u.Status == values[0].ToUpper()));
            }

            return result;
        }

        public IQueryable<ProjectInvoiceResponses> PeriodeInvoice(IQueryable<ProjectInvoiceResponses> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                var listPeriod = values[0].Split(';').ToList();
                result = source.Where(s => s.Invoices.Any(u => u.InvoiceDate >= System.DateTime.Parse(listPeriod[0]) && u.InvoiceDate <= System.DateTime.Parse(listPeriod[1])));
            }

            return result;
        }

        public IQueryable<ExpenseDto> PeriodeExpense(IQueryable<ExpenseDto> source, string op, string[] values)
        {
            var result = source;
            if (values.Length > 0)
            {
                var listPeriod = values[0].Split(';').ToList();
                result = source.Where(s => s.TransactionDate >= System.DateTime.Parse(listPeriod[0]) && s.TransactionDate <= System.DateTime.Parse(listPeriod[1]));
            }

            return result;
        }
    }
}
