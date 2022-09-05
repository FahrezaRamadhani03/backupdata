// <copyright file="UserSessionRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class UserSessionRepository : RepositoryBase<UserSession>, IUserSessionRepository
    {
        public async Task AddOrUpdate(UserSession model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data != null)
            {
                data.Jti = model.Jti;
                data.RefreshToken = model.RefreshToken;
                data.DateRevoked = model.DateRevoked;
                data.UserId = model.UserId;
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

        public async Task<UserSession> GetRefreshToken(Guid userId, string jti, bool revoked)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.Jti == jti && x.DateRevoked == null);
            return data;
        }

        public async Task<UserSession> GetRefreshToken(string jti, bool revoked, DateTime expired)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Jti == jti && x.DateRevoked == null && x.DateExpired > expired);
            return data;
        }

        public async Task<List<UserSession>> GetRefreshToken(Guid userId, bool revoked, DateTime expired)
        {
            var data = await this.dbSet.Where(x => x.UserId == userId && x.DateRevoked == null && x.DateExpired > expired).ToListAsync();
            return data;
        }
    }
}
