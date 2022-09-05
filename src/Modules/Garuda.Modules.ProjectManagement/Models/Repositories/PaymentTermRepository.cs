// <copyright file="PaymentTermRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class PaymentTermRepository : RepositoryBase<PaymentTerm>, IPaymentTermRepository
    {
        public async Task AddOrUpdate(PaymentTerm model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.Amount = model.Amount;
                data.InvoiceDate = model.InvoiceDate;
                data.InvoiceNote = model.InvoiceNote;
                data.Percentage = model.Percentage;
                data.Remarks = model.Remarks;
                data.ReminderDate = model.ReminderDate;
                data.TermNo = model.TermNo;
                data.Title = model.Title;
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

        public async Task<PaymentTerm> GetData(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<PaymentTerm>> GetData()
        {
            var data = await this.dbSet.ToListAsync();
            return data;
        }

        public async Task<List<PaymentTerm>> GetDataByUnpaid(Guid projectId)
        {
            var data = await this.dbSet.Where(x => x.InvoiceId == null && x.ProjectId == projectId)
                .ToListAsync();
            return data;
        }

        public async Task<List<PaymentTerm>> GetDataByUnpaid()
        {
            var data = await this.dbSet.Where(x => x.InvoiceId == null && x.DeletedDate == null)
                .Include(u => u.ProjectDetail)
                .ToListAsync();
            return data;
        }

        public async Task<bool> IsPaymentTermHasInvoice(Guid id)
        {
            var data = await this.dbSet.Where(x => x.Id == id && x.InvoiceId == null)
               .FirstOrDefaultAsync();
            return data != null;
        }
    }
}
