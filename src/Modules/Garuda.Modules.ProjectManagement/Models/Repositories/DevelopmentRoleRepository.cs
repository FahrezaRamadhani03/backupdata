// <copyright file="DevelopmentRoleRepository.cs" company="CV Garuda Infinity Kreasindo">
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
using Newtonsoft.Json;

namespace Garuda.Modules.ProjectManagement.Models.Repositories
{
    public class DevelopmentRoleRepository : RepositoryBase<DevelopmentRole>, IDevelopmentRoleRepository
    {
        public async Task AddOrUpdate(DevelopmentRole model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id &&
                x.Code == model.Code && x.Name.Trim().ToLower() == model.Name.Trim().ToLower());
            if (data == null)
            {
                await this.dbSet.AddAsync(model);
            }
        }

        public async Task UpdateData(DevelopmentRole model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (data != null)
            {
                data.Code = model.Code;
                data.Name = model.Name;
                data.Leader = model.Leader;
                data.Level = model.Level;
                this.dbSet.Update(data);
            }
        }

        public async Task<DevelopmentRole> FindByCodeAndName(DevelopmentRole model)
        {
            var registeredRoleByContrains = await this.dbSet.FirstOrDefaultAsync(x =>
                (x.Code.Trim().ToLower() == model.Code.Trim().ToLower() ||
                x.Name.Trim().ToLower() == model.Name.Trim().ToLower()));
            if (registeredRoleByContrains != null)
            {
                return registeredRoleByContrains;
            }

            return null;
        }

        public async Task<DevelopmentRole> FindByName(string name)
        {
            var registeredRoleByContrains = await this.dbSet.FirstOrDefaultAsync(x =>
                                                         x.Name.Trim().ToLower() == name.Trim().ToLower());
            if (registeredRoleByContrains != null)
            {
                return registeredRoleByContrains;
            }

            return null;
        }

        public async Task<DevelopmentRole> FindById(Guid id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }

            return null;
        }

        public async Task<List<DevelopmentRole>> GetList()
        {
            var datas = await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
            return datas;
        }

        public async Task<List<string>> GetListMapLevel()
        {
            var datas = await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
            List<string> developmentRoles = new List<string> { };

            if (datas.Count > 0)
            {
                foreach (var data in datas)
                {
                    if (data.Level != null)
                    {
                        List<string> level = JsonConvert.DeserializeObject<List<string>>(data.Level);
                        if (level != null)
                        {
                            foreach (var l in level)
                            {
                                developmentRoles.Add(String.Concat(data.Name, " ", l));
                            }
                        }
                        else
                        {
                            developmentRoles.Add(data.Name);
                        }
                    }
                    else
                    {
                        developmentRoles.Add(data.Name);
                    }
                }
            }

            return developmentRoles;
        }

        public (bool, string) Delete(Guid id)
        {
            var data = this.dbSet.Include(x => x.ProjectResources).FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                if (data.ProjectResources.Count >= 1)
                {
                    return (false, data.Name);
                }

                this.dbSet.Remove(data);
            }

            return (true, string.Empty);
        }
    }
}
