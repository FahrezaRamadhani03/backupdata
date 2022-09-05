// <copyright file="ContractInfoRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ContractInfoRepository : RepositoryBase<ContractInfo>, IContractInfoRepository
    {
        public async Task AddOrUpdate(ContractInfo model)
        {
            var data = await this.dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.ProjectId == model.ProjectId);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                data.ClientContractNo = model.ClientContractNo;
                data.ClientFileName = model.ClientFileName;
                data.ClientFileNameOri = model.ClientFileNameOri;
                data.GikContractNo = model.GikContractNo;
                data.GikFileName = model.GikFileName;
                data.GikFileNameOri = model.GikFileNameOri;
                data.OtherInfo = model.OtherInfo;
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
                if (data.ClientFileName != null)
                {
                    FileHelper.DeleteFile(data.ClientFileName, @"media\\proposal\\" + data.ClientFileName.Substring(0, 6));
                    data.ClientFileName = null;
                }

                if (data.GikFileName != null)
                {
                    FileHelper.DeleteFile(data.GikFileName, @"media\\proposal\\" + data.GikFileName.Substring(0, 6));
                    data.GikFileName = null;
                }

                this.dbSet.Remove(data);
            }
        }

        public async Task<ContractInfo> GetbyProject(Guid projectId)
        {
            var data = await this.dbSet
                .FirstOrDefaultAsync(x => x.ProjectId == projectId);
            return data;
        }

        public async Task<bool> IsRegisteredClientContractNo(string parameter, Guid projectId)
        {
            var data = await this.dbSet
              .FirstOrDefaultAsync(x => x.ClientContractNo == parameter && x.ProjectId != projectId);
            if (data == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> IsRegisteredGarudaContractNo(string parameter, Guid projectId)
        {
            var data = await this.dbSet
                         .FirstOrDefaultAsync(x => x.GikContractNo == parameter && x.ProjectId != projectId);
            if (data == null)
            {
                return false;
            }

            return true;
        }
    }
}
