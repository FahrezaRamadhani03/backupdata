// <copyright file="ProjectResourceRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProjectResourceRepository : RepositoryBase<ProjectResources>, IProjectResourceRepository
    {
        public async Task AddOrUpdate(ProjectResources model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id &&
                x.RoleId == model.RoleId && x.Level == model.Level && x.DeletedDate == null);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Qty = model.Qty;
                this.dbSet.Update(data);
            }
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id && x.DeletedDate == null);
            if (data != null)
            {
                this.dbSet.Remove(data);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ProjectResources> GetByName(Guid projectId, string roleName, string level)
        {
            var data = await this.dbSet.Include(u => u.DevelopmentRole)
                       .FirstOrDefaultAsync(x => x.ProjectId == projectId && x.DevelopmentRole.Name == roleName && x.Level == level && x.DeletedDate == null);
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProjectResources>> GetDataByProjectId(Guid id)
        {
            var data = await this.dbSet.Include(u => u.DevelopmentRole).Where(u => u.ProjectId == id && u.DeletedDate == null).ToListAsync();
            return data;
        }
    }
}
