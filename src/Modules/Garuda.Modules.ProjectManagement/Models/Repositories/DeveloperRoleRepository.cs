// <copyright file="DeveloperRoleRepository.cs" company="CV Garuda Infinity Kreasindo">
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
using Newtonsoft.Json;

namespace Garuda.Modules.ProjectManagement.Models.Repositories
{
    public class DeveloperRoleRepository : RepositoryBase<DeveloperRole>, IDeveloperRoleRepository
    {
        public async Task AddOrUpdate(DeveloperRole model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                this.dbSet.Update(data);
            }
        }

        public async Task<DeveloperRole> FindById(DeveloperRole developerRole)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.DeveloperId == developerRole.DeveloperId
                && x.RoleId == developerRole.RoleId && x.LevelId == developerRole.LevelId);
            return data;
        }

        public async Task<List<DeveloperRole>> GetList()
        {
            var datas = await this.dbSet.ToListAsync();
            return datas;
        }
    }
}
