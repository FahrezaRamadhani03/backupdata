// <copyright file="EmployeeRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public async Task AddOrUpdate(Employee model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            Console.WriteLine(data);
            if (data != null)
            {
                this.dbSet.Update(data);
            }
            else
            {
                await this.dbSet.AddAsync(model);
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

        public async Task<Employee> GetData(Guid id)
        {
            var data = await this.dbSet
            .Include(x => x.Developers).ThenInclude(x => x.ProjectDevelopmentTeams).ThenInclude(x => x.ProjectDetail)
            .FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<Employee> GetData(string parameter)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => (x.Email.ToLower() == parameter.ToLower() ||
            x.Fullname.ToLower() == parameter.ToLower()) &&
            x.DeletedDate == null);
            return data;
        }

        public async Task<List<Employee>> GetData()
        {
            var datas = await this.dbSet
            .Include(x => x.Developers).ThenInclude(x => x.ProjectDevelopmentTeams).ThenInclude(x => x.ProjectDetail)
            .Include(x => x.Developers).ThenInclude(x => x.DeveloperRoles).ThenInclude(x => x.DevelopmentRole)
            .Include(x => x.Developers).ThenInclude(x => x.DeveloperRoles).ThenInclude(x => x.Level)
            .ToListAsync();
            return datas;
        }

        public async Task<Employee> GetDataByUserId(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.UserId == id);
            return data;
        }
    }
}
