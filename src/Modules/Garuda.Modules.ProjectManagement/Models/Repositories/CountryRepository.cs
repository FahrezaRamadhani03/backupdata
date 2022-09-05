﻿// <copyright file="CountryRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public async Task AddOrUpdate(Country model)
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

        public async Task Delete(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                this.dbSet.Remove(data);
            }
        }

        public async Task<Country> GetData(Guid id)
        {
            var data = await this.dbSet.Include(u => u.Provinces).FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<Country> GetData(string name)
        {
            var data = await this.dbSet.Include(u => u.Provinces).FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return data;
        }

        public async Task<List<Country>> GetData()
        {
            var data = await this.dbSet.Include(u => u.Provinces).ToListAsync();
            return data;
        }

        public async Task<bool> IsRegisteredName(string name)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return data != null ? true : false;
        }
    }
}
