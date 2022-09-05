// <copyright file="ProjectScrumTeamRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProjectScrumTeamRepository : RepositoryBase<ProjectScrumTeam>, IProjectScrumTeamRepository
    {
        public async Task AddOrUpdate(ProjectScrumTeam model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.ProjectId == model.ProjectId);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.PoDeveloper = model.PoDeveloper;
                data.SmDeveloperId = model.SmDeveloperId;
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

        public async Task<ProjectScrumTeam> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<ProjectScrumTeam>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }
    }
}
