// <copyright file="CityRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    

    public class ExpenseBillRepository : RepositoryBase<ExpenseBill>, IExpenseBillRepository
    {
        public async Task AddOrUpdate(ExpenseBill model)
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

        public async Task<bool> Delete(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                this.dbSet.Remove(data);
                return true;
            }
            return false;
        }

        public async Task<ExpenseBill> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<ExpenseBill>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<List<ExpenseBill>> GetDataByExpenseId(Guid id)
        {
            var data = await this.dbSet.Include(u => u.Expense).Where(u => u.Expense.Id == id).ToListAsync();
            return data;
        }
    }
}
