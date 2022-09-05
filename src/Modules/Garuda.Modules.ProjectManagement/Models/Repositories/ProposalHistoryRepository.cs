// <copyright file="ProposalHistoryRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProposalHistoryRepository : RepositoryBase<ProposalHistory>, IProposalHistoryRepository
    {
        public async Task<ProposalHistory> AddData(ProposalHistory model)
        {
            try
            {
                var result = await dbSet.AddAsync(model);

                return model;
            }
            catch (Exception ex)
            {
                var err = ex;
                throw;
            }
        }

        public async Task<List<ProposalHistory>> GetbyProject(Guid projectId)
        {
            var data = await this.dbSet.IgnoreQueryFilters()
                .Where(x => x.ProjectId == projectId).ToListAsync();
            return data;
        }
    }
}
