// <copyright file="ProjectHistoryRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProjectHistoryRepository : RepositoryBase<ProjectHistory>, IProjectHistoryRepository
    {
        public async Task<List<ProjectHistory>> GetbyProject(Guid projectId)
        {
            var data = await this.dbSet
                .Where(x => x.ProjectId == projectId).OrderBy(x => x.CreatedDate).ToListAsync();
            return data;
        }

        public async Task<ProjectHistory> AddData(ProjectHistory model)
        {
            try
            {
                var result = await dbSet.AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                var err = ex;
                throw;
            }
        }
    }
}
