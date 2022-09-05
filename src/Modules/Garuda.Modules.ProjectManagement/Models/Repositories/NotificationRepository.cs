// <copyright file="NotificationRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public async Task AddOrUpdate(Notification model)
        {
             await this.dbSet.AddAsync(model);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetData(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Notification>> GetData()
        {
            var data = await this.dbSet.Include(u => u.Project)
                .Include(u => u.Employee)
                .OrderByDescending(u => u.CreatedDate)
                .ToListAsync();

            return data;
        }
    }
}
