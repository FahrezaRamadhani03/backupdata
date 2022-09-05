// <copyright file="DevelopmentHolidayRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class DevelopmentHolidayRepository : RepositoryBase<DevelopmentHoliday>, IDevelopmentHolidayRepository
    {
        public async Task AddOrUpdate(DevelopmentHoliday model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id && x.DeletedDate == null);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Description = model.Description ?? data.Description;
                data.HolidayDate = model.HolidayDate;
                this.dbSet.Update(data);
            }
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id && x.DeletedDate == null);
            if (data != null)
            {
                this.dbSet.Remove(data);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<DevelopmentHoliday>> GetList()
        {
            var datas = await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
            return datas;
        }

        public async Task<List<DevelopmentHoliday>> GetListByDevelopmentScrumSprintId(Guid id)
        {
            var data = await this.dbSet.Where(u => u.DevelopmentScrumSprintId == id && u.DeletedDate == null).ToListAsync();
            return data;
        }
    }
}
