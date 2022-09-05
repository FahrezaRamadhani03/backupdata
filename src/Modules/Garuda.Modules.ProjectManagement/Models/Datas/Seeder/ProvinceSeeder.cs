// <copyright file="ProvinceSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class ProvinceSeeder
    {
        public static Province[] Seed()
        {
            return new Province[]
            {
                new Province
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-6daa96531001"),
                    Name = "Jawa Barat", Code = "JB",
                    CountryId = new Guid("d45cb8d2-435e-4661-89d5-5daa96531001"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Province
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-6daa96531002"),
                    Name = "Jawa Tengah", Code = "JT",
                    CountryId = new Guid("d45cb8d2-435e-4661-89d5-5daa96531001"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
