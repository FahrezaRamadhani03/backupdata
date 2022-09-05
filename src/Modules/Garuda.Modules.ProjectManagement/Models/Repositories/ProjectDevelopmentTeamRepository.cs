// <copyright file="ProjectDevelopmentTeamRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProjectDevelopmentTeamRepository : RepositoryBase<ProjectDevelopmentTeam>, IProjectDevelopmentTeamRepository
    {
        public async Task AddOrUpdate(ProjectDevelopmentTeam model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.DeveloperId = model.DeveloperId;
                data.ProjectId = model.ProjectId;
                data.ManADay = model.ManADay;
                data.StartDate = model.StartDate;
                data.EndDate = model.EndDate;
                data.ManDays = model.ManDays;
                data.IsLeader = model.IsLeader;
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

        public async Task<ProjectDevelopmentTeam> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<ProjectDevelopmentTeam>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<List<ProjectDevelopmentTeam>> GetByProject(Guid projectId)
        {
            var data = await this.dbSet.Include(x => x.Developer).Where(x => x.ProjectId == projectId).ToListAsync();
            return data;
        }

        public async Task<decimal> GetManDaysAmountByProject(Guid projectId)
        {
            decimal totalAmount = 0;
            var data = await this.dbSet.Include(x => x.Developer).Where(x => x.ProjectId == projectId).ToListAsync();
            foreach (var developer in data)
            {
                totalAmount = totalAmount + (developer.ManADay * developer.ManDays * developer.Developer.RatePerDay);
            }

            return totalAmount;
        }
    }
}
