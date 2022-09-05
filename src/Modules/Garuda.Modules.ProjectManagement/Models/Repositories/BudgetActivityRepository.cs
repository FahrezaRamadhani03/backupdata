// <copyright file="BudgetActivityRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetActivityRepository : RepositoryBase<BudgetActivity>, IBudgetActivityRepository
    {
        public async Task AddOrUpdate(BudgetActivity model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Name = model.Name;
                data.IsShowInProjectExpense = model.IsShowInProjectExpense;
                data.BudgetTypeId = model.BudgetTypeId;
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

        public async Task DeleteByTypeId(Guid id)
        {
            var data = await this.dbSet.Where(x => x.BudgetTypeId == id).ToListAsync();
            if (data != null)
            {
                this.dbSet.RemoveRange(data);
            }
        }

        public async Task<BudgetActivity> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<BudgetActivity>> GetData()
        {
            var data = await this.dbSet.Include(u => u.BudgetType).ToListAsync();
            return data;
        }

        public async Task<bool> IsRegistered(string name, Guid? currentId)
        {
            if (currentId == null)
            {
                var data = await this.dbSet.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.DeletedDate == null);
                if (data == null)
                {
                    return false;
                }
            }
            else
            {
                var data = await this.dbSet.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id != currentId && x.DeletedDate == null);
                if (data == null)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsRegistered(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return false;
            }

            return true;
        }
    }
}
