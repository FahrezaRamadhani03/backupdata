// <copyright file="ClientRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public async Task<Client> AddData(Client model)
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

        public async Task Delete(int id)
        {
            var data = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                dbSet.Remove(data);
            }
        }

        public async Task<List<Client>> GetData(bool isActive)
        {
            if (isActive)
            {
                var datas = await dbSet.Include(u => u.ProjectDetails).ToListAsync();
                return datas;
            }
            else
            {
                var datas = await dbSet.Include(u => u.ProjectDetails).ToListAsync();
                return datas;
            }
        }

        public async Task<Client> GetbyCode(string code)
        {
            var data = await dbSet
                .FirstOrDefaultAsync(x => x.Code == code);
            return data;
        }

        public async Task<Client> GetDataById(int Id)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == Id);
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<Client> GetProjectListById(int Id)
        {
            var data = await this.dbSet
                      .Include(u => u.ProjectDetails)
                      .ThenInclude(u => u.DevelopmentScrums)
                      .ThenInclude(u => u.DevelopmentScrumSprints)
                      .FirstOrDefaultAsync(x => x.Id == Id);
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> SoftDeleteData(int id)
        {
            var data = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                dbSet.Remove(data);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateData(int id, Client model)
        {
            var data = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return false;
            }

            data.Name = model.Name;
            data.City = model.City;
            data.Code = model.Code;
            data.Country = model.Country;
            data.District = model.District;
            data.Address = model.Address;
            data.State = model.State;
            data.ZipCode = model.ZipCode;
            data.PICPhone = model.PICPhone;
            data.PICEmail = model.PICEmail;
            data.PICName = model.PICName;
            data.InvoiceName = model.InvoiceName;
            data.InvoiceEmail = model.InvoiceEmail;
            this.dbSet.Update(data);
            return true;
        }
    }
}
