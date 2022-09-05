// <copyright file="GroupMenuPermissionRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class GroupMenuPermissionRepository : RepositoryBase<GroupMenuPermission>, IGroupMenuPermissionsRepository
    {
        public async Task AddOrUpdate(GroupMenuPermission model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.CanCreate = model.CanCreate;
                data.CanDelete = model.CanDelete;
                data.CanSubmit = model.CanSubmit;
                data.CanUpdate = model.CanUpdate;
                data.CanView = model.CanView;
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

        public async Task<GroupMenuPermission> GetById(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<GroupMenuPermission>> GetList()
        {
            var datas = await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
            return datas;
        }

        public async Task<List<GroupMenuPermission>> GetList(Guid id, bool byMenu)
        {
            if (byMenu)
            {
                var datas = await this.dbSet.Where(x => x.DeletedDate == null && x.MenuId == id).ToListAsync();
                return datas;
            }
            else
            {
                var datas = await this.dbSet.Where(x => x.DeletedDate == null && x.GroupId == id).ToListAsync();
                return datas;
            }
        }

        public async Task<List<GroupMenuPermission>> GetList(Guid menuId, Guid groupId)
        {
            var datas = await this.dbSet.Where(x => x.DeletedDate == null && x.MenuId == menuId && x.GroupId == groupId).ToListAsync();
            return datas;
        }
    }
}
