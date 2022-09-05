// <copyright file="ExpenseRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public async Task<Expense> AddOrUpdate(Expense model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                var result = await this.dbSet.AddAsync(model);
                return result.Entity;
            }
            else
            {
                data.TransactionDate = model.TransactionDate;
                data.Description = model.Description;
                data.ActivityId = model.ActivityId;
                data.ProjectId = model.ProjectId;
                data.BillAmount = model.BillAmount;
                var result = this.dbSet.Update(data);
                return result.Entity;
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

        public async Task<Expense> GetData(Guid id)
        {
            var data = await this.dbSet.Include(u => u.BudgetActivity).ThenInclude(u => u.BudgetType).Include(u => u.ExpenseBills).FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<Expense>> GetData()
        {
            var data = await this.dbSet.Include(u => u.BudgetActivity).ThenInclude(u => u.BudgetType).Include(u => u.ExpenseBills).ToListAsync();
            return data;
        }

        public async Task<List<Expense>> GetDataByProjectId(Guid id)
        {
            var data = await this.dbSet.Include(u => u.BudgetActivity).ThenInclude(u => u.BudgetType).Include(u => u.ExpenseBills).Where(u => u.ProjectDetail.Id == id).ToListAsync();
            return data;
        }

        public async Task<decimal> GetTotalExpenseAmountByProjectId(Guid id)
        {
            decimal totalAmount = 0;
            var data = await this.dbSet.Where(u => u.ProjectId == id && u.DeletedDate == null).Select(u => u.BillAmount).ToListAsync();
            foreach (var amount in data)
            {
                totalAmount = totalAmount + amount;
            }

            return totalAmount;
        }
    }
}
