// <copyright file="ProposalRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Common.Models.Datas;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Repositories
{
    public class ProposalRepository : RepositoryBase<Proposal>, IProposalRepository
    {
        public async Task AddOrUpdate(Proposal model)
        {
            var data = await this.dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.ProjectId == model.ProjectId);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.DocumentNo = model.DocumentNo;
                data.ProjectAmount = model.ProjectAmount;
                data.SentDate = model.SentDate;
                data.Remark = model.Remark;
                data.FileName = model.FileName;
                data.FileNameOri = model.FileNameOri;
                data.UpdatedDate = DateTime.Now;
                data.DeletedBy = null;
                data.DeletedDate = null;
                this.dbSet.Update(data);
            }
        }

        public async Task DeleteByProject(Guid projectId)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (data != null)
            {
                data.FileName = null;

                this.dbSet.Remove(data);
            }
        }

        public async Task<Proposal> GetbyProject(Guid projectId)
        {
            var data = await this.dbSet
                .FirstOrDefaultAsync(x => x.ProjectId == projectId);
            return data;
        }

        public async Task<decimal> GetProposalAmount(Guid projectId)
        {
            var data = await this.dbSet.Where(u => u.ProjectId == projectId).Select(u => u.ProjectAmount).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> IsRegisteredDocumentNo(string parameter, Guid projectId)
        {
            var data = await this.dbSet.Where(u => u.DocumentNo == parameter && u.ProjectId != projectId).FirstOrDefaultAsync();
            if (data == null)
            {
                return false;
            }

            return true;
        }
    }
}
