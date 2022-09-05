// <copyright file="ProjectFileRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProjectFileRepository : RepositoryBase<ProjectFile>, IProjectFileRepository
    {
        public async Task AddOrUpdate(ProjectFile model, string projectCode)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
            else
            {
                if (data.FileName != null)
                {
                    FileHelper.DeleteFile(data.FileName, @"media\\projectfiles\\" + projectCode + @"\\" + data.FileName);
                }

                data.DocumentDesc = model.DocumentDesc;
                data.DocumentName = model.DocumentName;
                data.FileSource = model.FileSource;
                data.Link = model.Link;
                data.FileName = model.FileName;
                data.FileNameOri = model.FileNameOri;
                data.UpdatedDate = DateTime.Now;
                data.DeletedBy = null;
                data.DeletedDate = null;
                this.dbSet.Update(data);
            }
        }

        public async Task Delete(int id, string projectCode)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                if (data.FileName != null) FileHelper.DeleteFile(data.FileName, @"media\\projectfiles\\" + projectCode + @"\\" + data.FileName);
                this.dbSet.Remove(data);
            }
        }

        public async Task<List<ProjectFile>> GetbyProject(Guid projectId)
        {
            var data = await this.dbSet
                .Where(x => x.ProjectId == projectId).ToListAsync();
            return data;
        }

        public async Task<List<int>> GetAllIdbyProject(Guid projectId)
        {
            var data = await this.dbSet
                .Where(x => x.ProjectId == projectId).Select(x => x.Id).ToListAsync();
            return data;
        }

        public async Task<(string, string)> GetOriginalFileName(string fileName)
        {
            var data = await this.dbSet.Include(u => u.Project)
                .Where(x => x.FileName == fileName).Select(x => new { FileName = x.FileNameOri, ProjectCode = x.Project.Code }).FirstOrDefaultAsync();
            if (data != null)
            {
                return (data.FileName, data.ProjectCode);
            }

            return (null, null);
        }
    }
}
