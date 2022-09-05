// <copyright file="TaxRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class TaxRepository : RepositoryBase<Tax>, ITaxRepository
    {
        public async Task AddOrUpdate(Tax model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Name = model.Name;
                data.IsActive = model.IsActive;
                data.Rate = model.Rate;
                data.Code = model.Code;
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

        public async Task<Tax> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<Tax>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<Tax> GetData(string name)
        {
            var data = await this.dbSet
                .FirstOrDefaultAsync(x => x.Name.Contains(name));
            return data;
        }

        public async Task<bool> IsRegisteredById(Guid id)
        {
            var data = await this.dbSet.Select(u => new { Id = u.Id, DeletedDate = u.DeletedDate })
               .Where(x => x.Id == id && x.DeletedDate == null).FirstOrDefaultAsync();
            if (data == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> IsRegisteredCode(string code)
        {
            var data = await this.dbSet.Select(u => new { Code = u.Code, DeletedDate = u.DeletedDate })
                .Where(x => x.Code == code && x.DeletedDate == null).FirstOrDefaultAsync();
            if (data == null)
            {
                return false;
            }

            return true;
        }

        public async Task UpdateNonActiveTaxByName(string name)
        {
            var data = await this.dbSet.Where(u => u.Name.ToLower() == name.ToLower() &&
            u.DeletedDate == null).ToListAsync();
            foreach (var tax in data)
            {
                tax.IsActive = false;
                this.dbSet.Update(tax);
            }
        }
    }
}
