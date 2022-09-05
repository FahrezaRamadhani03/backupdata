// <copyright file="DevelopmentScrumRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class DevelopmentScrumRepository : RepositoryBase<DevelopmentScrum>, IDevelopmentScrumRepository
    {
        public async Task AddOrUpdate(DevelopmentScrum model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => (x.Id == model.Id || x.ProjectId == model.ProjectId) && x.DeletedDate == null);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Quantity = model.Quantity;
                data.DaysInSprint = model.DaysInSprint ?? data.DaysInSprint;
                this.dbSet.Update(data);
            }
        }

        public async Task<DevelopmentScrum> GetDataByProjectId(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.ProjectId == id && x.DeletedDate == null);
            return data;
        }

        public async Task<List<DevelopmentScrum>> GetList()
        {
            var datas = await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
            return datas;
        }

        public async Task<DevelopmentScrum> GetDataSprintByProject(Guid projectId)
        {
            var datas = await this.dbSet.Where(x => x.ProjectId == projectId)
                .Include(u => u.DevelopmentScrumSprints.OrderBy(x => x.SprintStart)).FirstOrDefaultAsync();
            return datas;
        }
    }
}
