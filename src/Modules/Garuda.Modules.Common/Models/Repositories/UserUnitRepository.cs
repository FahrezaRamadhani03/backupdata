// <copyright file="UserUnitRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Common.Models.Repositories
{
    public class UserUnitRepository : RepositoryBase<UserUnit>, IUserUnitRepository
    {
        public async Task AddOrUpdate(UserUnit model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data != null)
            {
                data.UserId = model.UserId;
                data.UnitId = model.UnitId;
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

        public async Task<UserUnit> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<UserUnit>> GetData(Guid id, bool isUser)
        {
            if (isUser)
            {
                var datas = await this.dbSet.Where(x => x.UserId == id && x.DeletedDate == null).ToListAsync();
                return datas;
            }
            else
            {
                var datas = await this.dbSet.Where(x => x.UnitId == id && x.DeletedDate == null).ToListAsync();
                return datas;
            }
        }

        public async Task<UserUnit> GetUserByMineHead(Guid id)
        {
            var data = await this.dbSet
                .Include(x => x.User)
                .ThenInclude(x => x.UserGroups)
                .ThenInclude(x => x.Group)
                .FirstOrDefaultAsync(x => x.UnitId == id && x.DeletedDate == null &&
                x.User.UserGroups.Any(b => b.GroupId == Guid.Parse("fa997ce4-5b76-447c-9b08-5f448f185ad3") && b.DeletedDate == null));
            return data;
        }
    }
}
