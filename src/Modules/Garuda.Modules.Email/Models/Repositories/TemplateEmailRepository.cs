// <copyright file="TemplateEmailRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Modules.Email.Models.Contracts;
using Garuda.Modules.Email.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Email.Models.Repositories
{
    public class TemplateEmailRepository : RepositoryBase<TemplateEmail>, ITemplateEmailRepository
    {
        public async Task AddOrUpdate(TemplateEmail model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
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

        public async Task<TemplateEmail> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<TemplateEmail>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<TemplateEmail> GetData(string subject)
        {
            var data = await this.dbSet
                .FirstOrDefaultAsync(x => x.Subject.Contains(subject));
            return data;
        }
    }
}
