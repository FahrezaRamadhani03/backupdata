// <copyright file="BudgetTypeRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetTypeRepository : RepositoryBase<BudgetType>, IBudgetTypeRepository
    {
        public async Task AddOrUpdate(BudgetType model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.TypeName = model.TypeName;
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

        public async Task<BudgetType> GetData(Guid id)
        {
            var data = await this.dbSet.Include(u => u.BudgetActivities).FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<BudgetType>> GetData()
        {
            var data = await this.dbSet.Include(u => u.BudgetActivities).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return data;
        }

        public async Task<List<BudgetType>> GetDataByBudgetId(Guid id)
        {
            var data = await this.dbSet.Include(u => u.BudgetActivities).ThenInclude(u => u.BudgetDetails.Where(x => x.BudgetId == id)).ToListAsync();
            return data;
        }
        
        public async Task<bool> IsRegistered(string name, Guid? currentId)
        {
            if (currentId == null)
            {
                var data = await this.dbSet.FirstOrDefaultAsync(x => x.TypeName.ToLower() == name.ToLower() && x.DeletedDate == null);
                if (data == null)
                {
                    return false;
                }
            }
            else
            {
                var data = await this.dbSet.FirstOrDefaultAsync(x => x.TypeName.ToLower() == name.ToLower() && x.Id != currentId && x.DeletedDate == null);
                if (data == null)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsRegistered(Guid id)
        {
            var data = await this.dbSet.Include(u => u.BudgetActivities).FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return false;
            }

            return true;
        }
    }
}
