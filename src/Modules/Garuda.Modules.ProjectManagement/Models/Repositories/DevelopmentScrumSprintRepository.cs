// <copyright file="DevelopmentScrumSprintRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class DevelopmentScrumSprintRepository : RepositoryBase<DevelopmentScrumSprint>, IDevelopmentScrumSprintRepository
    {
        public async Task<DevelopmentScrumSprint> AddOrUpdate(DevelopmentScrumSprint model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id && x.DeletedDate == null);
            if (data == null)
            {
                var result = await this.dbSet.AddAsync(model);
                return result.Entity;
            }
            else
            {
                data.Sprintname = model.Sprintname ?? data.Sprintname;
                data.SprintStart = model.SprintStart;
                data.SprintEnd = model.SprintEnd;
                data.DayLength = model.DayLength;
                data.HolidayLength = model.HolidayLength;
                data.Remark = model.Remark;
                var result = this.dbSet.Update(data);
                return result.Entity;
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

        public async Task<DateTime> GetLastSprintDate(Guid id)
        {
            var data = await this.dbSet.Where(u => u.DevelopmentScrumId == id && u.DeletedDate == null)
                .OrderByDescending(u => u.SprintEnd).Select(u => u.SprintEnd)
                .FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<DevelopmentScrumSprint>> GetList()
        {
            var datas = await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
            return datas;
        }

        public async Task<List<DevelopmentScrumSprint>> GetListByDevScrumId(Guid id)
        {
            var data = await this.dbSet.Where(u => u.DevelopmentScrumId == id && u.DeletedDate == null).ToListAsync();
            return data;
        }
    }
}
