// <copyright file="BudgetRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetRepository : RepositoryBase<Budget>, IBudgetRepository
    {
        public async Task AddOrUpdate(Budget model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Projection = model.Projection;
                data.Year = model.Year;
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

        public async Task<Budget> GetData(Guid id)
        {
            var data = await this.dbSet.Include(x => x.BudgetDetails).ThenInclude(x => x.BudgetActivity).ThenInclude(x => x.BudgetType)
                .Include(x => x.BudgetDetails).ThenInclude(x => x.BudgetActivity).ThenInclude(x => x.Expenses)
                .FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<Budget>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<bool> IsExisBaseOnYear(int year)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Year == year);
            return data != null;
        }
    }
}
