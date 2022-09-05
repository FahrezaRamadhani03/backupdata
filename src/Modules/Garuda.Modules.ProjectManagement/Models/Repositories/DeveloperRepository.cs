// <copyright file="DeveloperRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class DeveloperRepository : RepositoryBase<Developer>, IDeveloperRepository
    {
        public async Task AddOrUpdate(Developer model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Fullname = model.Fullname;
                data.EmployeeId = model.EmployeeId;
                data.ClientId = model.ClientId;
                this.dbSet.Update(data);
            }
        }

        public async Task Delete(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                this.dbSet.Remove(data);
            }
        }

        public async Task<Developer> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<Developer> GetDataByEmployeeId(Guid employeeId)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            return data;
        }

        public async Task<List<Developer>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<List<Developer>> GetDataByClientId(int? clientId)
        {
            var data = await this.dbSet.Where(x => x.ClientId == clientId || x.ClientId == null).ToListAsync();
            return data;
        }

        public async Task<List<Developer>> GetDataDevelopmentTeamAndProject()
        {
            var data = await this.dbSet.Include(u => u.ProjectDevelopmentTeams)
                                       .ThenInclude(u => u.DevelopmentTeamRoles).ThenInclude(u => u.DeveloperRole).ThenInclude(u => u.DevelopmentRole)
                                       .Include(u => u.ProjectDevelopmentTeams)
                                       .ThenInclude(u => u.ProjectDetail)
                                       .ThenInclude(u => u.DevelopmentScrums)
                                       .ThenInclude(u => u.DevelopmentScrumSprints)
                                       .Include(u => u.ProjectDevelopmentTeams)
                                       .ThenInclude(u => u.ProjectDetail)
                                       .ThenInclude(u => u.Client)
                                       .ToListAsync();
            return data;
        }
    }
}
