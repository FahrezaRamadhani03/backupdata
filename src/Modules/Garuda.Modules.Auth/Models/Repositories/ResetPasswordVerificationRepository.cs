// <copyright file="ResetPasswordVerificationRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Modules.Auth.Models.Contracts;
using Garuda.Modules.Auth.Models.Datas;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Auth.Models.Repositories
{
    public class ResetPasswordVerificationRepository : RepositoryBase<ResetPasswordVerification>, IResetPasswordVerificationRepository
    {
        public async Task AddOrUpdate(ResetPasswordVerification model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data != null)
            {
                this.dbSet.Update(data);
                data.ExpirationTime = model.ExpirationTime;
            }
            else
            {
                await this.dbSet.AddAsync(model);
            }
        }

        public async Task<ResetPasswordVerification> GetData(string code)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => (x.Code == code));
            return data;
        }

        public async Task<List<ResetPasswordVerification>> GetAllData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }
    }
}
