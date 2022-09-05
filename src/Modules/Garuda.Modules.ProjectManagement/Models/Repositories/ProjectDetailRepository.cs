// <copyright file="ProjectDetailRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Repositories
{
    public class ProjectDetailRepository : RepositoryBase<ProjectDetail>, IProjectDetailRepository
    {
        public async Task<List<ProjectDetail>> GetData(bool isActive)
        {
            if (isActive)
            {
                var datas = await dbSet.ToListAsync();
                return datas;
            }
            else
            {
                var datas = await dbSet.IgnoreQueryFilters().ToListAsync();
                return datas;
            }
        }

        public async Task<ProjectDetail> GetById(Guid id)
        {
            var datas = await dbSet.Include(u => u.Client)
                        .Include(u => u.DevelopmentScrums).ThenInclude(u => u.DevelopmentScrumSprints)
                        .Include(u => u.ProjectDevelopmentTeams)
                        .Include(u => u.DevelopmentHolidays)
                        .Include(u => u.Proposals)
                        .Include(u => u.Client)
                        .FirstOrDefaultAsync(x => x.Id == id);
            return datas;
        }

        public async Task AddOrUpdate(ProjectDetail model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.OverdueLength = model.OverdueLength;
                data.OverdueUnit = model.OverdueUnit;
                data.ClientId = model.ClientId;
                data.Code = model.Code;
                data.Description = model.Description;
                data.InitState = model.InitState;
                data.Key = model.Key;
                data.Name = model.Name;
                data.PICEmail = model.PICEmail;
                data.PICName = model.PICName;
                data.PICPhone = model.PICPhone;
                data.ShortDescription = model.ShortDescription;
                data.Status = model.Status;
                data.Technology = model.Technology;
                data.DevelopmentMethod = model.DevelopmentMethod ?? data.DevelopmentMethod;
                data.KickoffDate = model.KickoffDate ?? data.KickoffDate;
                data.DevelopmentStart = model.DevelopmentStart ?? data.DevelopmentStart;
                data.DevelopmentEnd = model.DevelopmentEnd ?? data.DevelopmentEnd;
                data.MaintenanceLength = model.MaintenanceLength;
                data.MaintenanceUnit = model.MaintenanceUnit ?? data.MaintenanceUnit;
                this.dbSet.Update(data);
            }
        }

        public async Task<bool> IsRegisteredByProjectKey(string key)
        {
            return await this.dbSet.AnyAsync(x => x.Key.ToLower() == key.ToLower() && x.DeletedDate == null);
        }

        public async Task<string> GetCodeAtLastData()
        {
            var data = await this.dbSet.OrderByDescending(u => u.Code).FirstOrDefaultAsync(x => x.CreatedDate.Value.Year == DateTime.Now.Year);
            if (data == null)
            {
                return null;
            }
            else
            {
                return data.Code;
            }
        }

        public async Task<bool> IsRegisteredById(Guid id)
        {
            return await this.dbSet.AnyAsync(x => x.Id == id && x.DeletedDate == null);
        }

        public async Task<ProjectDetail> FindById(Guid id)
        {
            var data = await this.dbSet.Include(u => u.Client)
                .Include(u => u.ProjectResources).ThenInclude(u => u.DevelopmentRole)
                .FirstOrDefaultAsync(x => x.Id == id && x.DeletedDate == null);
            if (data == null)
            {
                return null;
            }
            else
            {
                return data;
            }
        }

        public async Task<ProjectDetail> GetPaymentTermbyProjectId(Guid projectId)
        {
            var data = await this.dbSet
                .Include(x => x.PaymentTerms).ThenInclude(x => x.PaymentTermTaxes)
                .Include(x => x.Proposals)
                .FirstOrDefaultAsync(x => x.Id == projectId);
            return data;
        }

        public async Task<ProjectDetail> GetDevelopmentTeambyProjectId(Guid projectId)
        {
            var data = await this.dbSet
                .Include(x => x.ProjectScrumTeams).ThenInclude(x => x.SmDeveloper)
                .Include(x => x.ProjectDevelopmentTeams).ThenInclude(x => x.Developer)
                .Include(x => x.ProjectDevelopmentTeams).ThenInclude(x => x.DevelopmentTeamRoles).ThenInclude(x => x.DeveloperRole).ThenInclude(x => x.DevelopmentRole)
                .Include(x => x.ProjectDevelopmentTeams).ThenInclude(x => x.DevelopmentTeamRoles).ThenInclude(x => x.DeveloperRole).ThenInclude(x => x.Level)
                .FirstOrDefaultAsync(x => x.Id == projectId);
            return data;
        }

        public async Task<ProjectDetail> GetDevelopmentInfoByProjectId(Guid projectId)
        {
            var data = await this.dbSet.Include(u => u.Client)
                .Include(u => u.ProjectResources).ThenInclude(u => u.DevelopmentRole)
                .Include(u => u.DevelopmentScrums).ThenInclude(u => u.DevelopmentScrumSprints)
                .Include(u => u.DevelopmentHolidays)
                .FirstOrDefaultAsync(x => x.Id == projectId && x.DeletedDate == null);
            if (data == null)
            {
                return null;
            }
            else
            {
                return data;
            }
        }

        public async Task<List<ProjectDetail>> GetDataTimeline()
        {
            var datas = await dbSet.Include(u => u.Client)
                                   .Include(u => u.DevelopmentScrums).ThenInclude(u => u.DevelopmentScrumSprints)
                                   .ToListAsync();
            return datas;
        }

        public IQueryable<ProjectDetail> GetDataTimelineAsQueryable()
        {
            var datas = dbSet.Include(u => u.Client)
                                   .Include(u => u.DevelopmentScrums)
                                   .ThenInclude(u => u.DevelopmentScrumSprints)
                                   .AsQueryable();
            return datas;
        }

        public async Task<List<ProjectDetail>> GetDatabyLastUpdate()
        {
            var datas = await dbSet.Where(u => u.UpdatedDate != null).OrderByDescending(u => u.UpdatedDate).ToListAsync();
            return datas;
        }

        public async Task<List<ProjectDetail>> GetDatabyCreated()
        {
            var datas = await dbSet.Where(u => u.CreatedDate != null && u.UpdatedDate == null).OrderByDescending(u => u.CreatedDate).ToListAsync();
            return datas;
        }

        public async Task<List<ProjectDetail>> GetChangedStatusData()
        {
            var datas = await dbSet.Where(x => (x.DevelopmentStart <= DateTime.Now.Date) || (x.DevelopmentEnd < DateTime.Now.Date)).ToListAsync();
            return datas;
        }

        public async Task<List<ProjectDetail>> GetInvoices()
        {
            var datas = await dbSet.Include(u => u.Invoices).Include(u => u.Client).Where(u => u.Invoices.Any(u => u.Status == "Unpaid"))
                                   .ToListAsync();
            return datas;
        }

        public async Task<List<ProjectDetail>> GetAllInvoices()
        {
            var datas = await dbSet.Include(u => u.Invoices).ThenInclude(x => x.InvoicePayments)
                .Include(u => u.Client)
                .Include(u => u.Proposals)
                .Where(u => u.Invoices.Any())
                .ToListAsync();
            return datas;
        }

        public async Task<List<ProjectDetail>> GetProfitProject(int year)
        {
            var datas = await dbSet.Include(u => u.Expenses)
                .Include(u => u.Proposals).Where(x => x.DevelopmentStart.Value.Year == year || x.DevelopmentEnd.Value.Year == year)
                .ToListAsync();
            return datas;
        }

        public async Task UpdateStatus(Guid id, string status)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                data.Status = status;
                this.dbSet.Update(data);
            }
        }

        public async Task<int> GetLastInvoicesNo(Guid projectId)
        {
            int no = 0;
            var data = await this.dbSet.Where(x => x.Id == projectId).Include(x => x.Invoices)
               .FirstOrDefaultAsync();
            if (data?.Invoices != null)
            {
                foreach (var item in data.Invoices)
                {
                    if (item.DeletedDate == null)
                    {
                        no++;
                    }
                }
            }

            return no;
        }
    }
}
