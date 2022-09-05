// <copyright file="InvoiceRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Repositories
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public async Task AddOrUpdate(Invoice model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.AdditionalDiscount = model.AdditionalDiscount;
                data.AdditionalNote = model.AdditionalNote;
                data.DiscountTotal = model.DiscountTotal;
                data.InvoiceDate = model.InvoiceDate;
                data.InvoiceNo = model.InvoiceNo;
                data.IsAdditionalDiscount = model.IsAdditionalDiscount;
                data.OverdueDate = model.OverdueDate;
                data.OverdueLength = model.OverdueLength;
                data.OverdueUnit = model.OverdueUnit;
                data.PaymentTermId = model.PaymentTermId;
                data.ProjectId = model.ProjectId;
                data.Remarks = model.Remarks;
                data.ReminderDate = model.ReminderDate;
                data.Status = model.Status;
                data.Subtotal = model.Subtotal;
                data.TotalPayment = model.TotalPayment;
                data.BillingAddress = model.BillingAddress;
                data.CompanyName = model.CompanyName;
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

        public async Task<Invoice> GetData(Guid id)
        {
            var data = await this.dbSet
                .Include(x => x.ProjectDetail).ThenInclude(x => x.Client)
                .Include(x => x.ProjectDetail).ThenInclude(x => x.Proposals)
                .Include(x => x.PaymentTerm)
                .Include(x => x.InvoiceDetails)
                .Include(x => x.InvoiceDetailTaxes)
                .Include(x => x.InvoicePayments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<Invoice>> GetData()
        {
            var data = await this.dbSet
                .Include(x => x.ProjectDetail).ThenInclude(x => x.Client)
                .Include(x => x.ProjectDetail).ThenInclude(x => x.Proposals)
                .Include(x => x.PaymentTerm)
                .Include(x => x.InvoiceDetails)
                .Include(x => x.InvoiceDetailTaxes)
                .Include(x => x.InvoicePayments)
                .ToListAsync();
            return data;
        }

        public async Task<decimal> GetPaidInvoiceByProjectId(Guid id)
        {
            decimal unpaidTotalAmount = 0;
            var data = await this.dbSet.Where(u => u.ProjectId == id && u.Status == AppConstant.Paid)
                .Select(u => u.TotalPayment).ToListAsync();
            foreach (var cost in data)
            {
                unpaidTotalAmount = unpaidTotalAmount + cost;
            }

            return unpaidTotalAmount;
        }

        public async Task<(Guid, string)> GetProjectDataByInvoiceId(Guid id)
        {
            var data = await this.dbSet.Include(u => u.ProjectDetail)
                .Select(u => new { Id = u.Id, Name = u.ProjectDetail.Name, ProjectId = u.ProjectDetail.Id })
                .FirstOrDefaultAsync(x => x.Id == id);

            return (data.ProjectId, data.Name);
        }

        public async Task<decimal> GetUnpaidInvoiceByProjectId(Guid id)
        {
            decimal unpaidTotalAmount = 0;
            var data = await this.dbSet.Where(u => u.ProjectId == id && u.Status == AppConstant.Draft)
                .Select(u => u.TotalPayment).ToListAsync();
            foreach (var cost in data)
            {
                unpaidTotalAmount = unpaidTotalAmount + cost;
            }

            return unpaidTotalAmount;
        }

        public async Task<decimal> GetUnpaidOverdueInvoiceByProjectId(Guid id)
        {
            decimal unpaidTotalAmount = 0;
            var data = await this.dbSet.Where(u => u.ProjectId == id && u.Status == AppConstant.Draft &&
                DateTime.Now > u.OverdueDate)
                .Select(u => u.TotalPayment).ToListAsync();
            foreach (var cost in data)
            {
                unpaidTotalAmount = unpaidTotalAmount + cost;
            }

            return unpaidTotalAmount;
        }

        public async Task SendInvoice(SendInvoiceRequest model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.InvoiceId);
            if (data == null)
            {
            }
            else
            {
                data.SendDate = model.SendDate;
                data.Remarks = model.Remarks;
                data.Status = "UNPAID";
                this.dbSet.Update(data);
            }
        }

        public async Task SetPaid(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
            }
            else
            {
                data.Status = "PAID";
                this.dbSet.Update(data);
            }
        }
    }
}
