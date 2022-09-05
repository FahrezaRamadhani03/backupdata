// <copyright file="MenuRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public async Task AddOrUpdate(Menu model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(data);
            }
            else
            {
                data.DisplayName = model.DisplayName;
                data.Level = model.Level;
                data.ParentId = model.ParentId;
                data.Code = model.Code;
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

        public async Task<Menu> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<Menu>> GetData()
        {
            var data = await this.dbSet
                .Include(x => x.GroupMenuPermissions)
                .Where(x => x.DeletedDate == null)
                .ToListAsync();
            return data;
        }

        public async Task<List<Menu>> GetData(Guid id, bool isList)
        {
            var data = await this.dbSet
                .Include(x => x.GroupMenuPermissions)
                .Where(x => x.DeletedDate == null &&
                x.ParentId == id &&
                x.GroupMenuPermissions.Any(x => x.CanView)).
                ToListAsync();
            return data;
        }

        public async Task<List<Menu>> GetData(bool isParent, Guid userId)
        {
            var data = await this.dbSet
                .Include(x => x.GroupMenuPermissions)
                .ThenInclude(x => x.Group)
                .ThenInclude(x => x.UserGroups.Where(c => c.UserId == userId))
                .Where(x => x.DeletedDate == null &&
                x.ParentId == Guid.Empty &&
                x.GroupMenuPermissions.Any(x => x.CanView) &&
                x.GroupMenuPermissions.Any(b => b.Group.UserGroups.Any(c => c.UserId == userId)))
                .OrderBy(x => x.DisplayOrder).
                ToListAsync();
            return data;
        }
    }
}
