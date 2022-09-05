// <copyright file="HolidayRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class HolidayRepository : RepositoryBase<Holiday>, IHolidayRepository
    {
        public async Task AddOrUpdate(Holiday model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id && x.DeletedDate == null);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                this.dbSet.Update(data);
            }
        }

        public async Task<List<Holiday>> GetList()
        {
            var data = await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
            return data;
        }

        public async Task<List<Holiday>> GetList(DateTime start, DateTime end)
        {
            var data = await this.dbSet.Where(x => x.Date >= start && x.Date <= end).ToListAsync();
            return data;
        }
    }
}
