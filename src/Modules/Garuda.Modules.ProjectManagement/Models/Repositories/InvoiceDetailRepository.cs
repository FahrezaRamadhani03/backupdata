// <copyright file="InvoiceDetailRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class InvoiceDetailRepository : RepositoryBase<InvoiceDetail>, IInvoiceDetailRepository
    {
        public async Task AddOrUpdate(InvoiceDetail model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Quantity = model.Quantity;
                data.Price = model.Price;
                data.Discount = model.Discount;
                data.Description = model.Description;
                data.Subtotal = model.Subtotal;
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

        public async Task<InvoiceDetail> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<InvoiceDetail>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<List<Guid>> GetRegisteredInvoiceByInvoiceId(Guid id)
        {
            var data = await this.dbSet.Where(u => u.InvoiceId == id &&
                 u.DeletedDate == null)
                .Select(u => u.Id).ToListAsync();
            return data;
        }
    }
}
