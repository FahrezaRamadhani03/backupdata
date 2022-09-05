// <copyright file="UserRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Common.Models.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public async Task AddOrUpdate(User model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            Console.WriteLine(data);
            if (data != null)
            {
                data.Email = model.Email;
                data.IsActive = model.IsActive;
                data.LastLogin = model.LastLogin;
                data.Username = model.Username;
                data.Fullname = model.Fullname;
                this.dbSet.Update(data);
            }
            else
            {
                await this.dbSet.AddAsync(model);
            }
        }

        public async Task UpdatePassword(User model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            Console.WriteLine(data);
            if (data != null)
            {
                data.Password = model.Password;
                data.UpdatedDate = DateTime.Now;
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

        public async Task<User> GetData(Guid id)
        {
            var data = await this.dbSet
                .Include(x => x.UserUnits).ThenInclude(x => x.Unit)
                .Include(x => x.UserGroups).ThenInclude(x => x.Group)
                .FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<User> GetData(string parameter)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => (x.Email.ToLower() == parameter.ToLower() ||
            x.Username.ToLower() == parameter.ToLower()));
            return data;
        }

        public async Task<List<User>> GetData(bool isActive)
        {
            if (isActive)
            {
                var datas = await this.dbSet
                .Include(x => x.UserUnits).ThenInclude(x => x.Unit)
                .Include(x => x.UserGroups).ThenInclude(x => x.Group)
                .Where(x => x.DeletedDate == null).ToListAsync();
                return datas;
            }
            else
            {
                var datas = await this.dbSet.ToListAsync();
                return datas;
            }
        }
    }
}
