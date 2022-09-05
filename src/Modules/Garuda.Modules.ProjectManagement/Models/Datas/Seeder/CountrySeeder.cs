// <copyright file="CountrySeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class CountrySeeder
    {
        public static Country[] Seed()
        {
            return new Country[]
            {
                new Country
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-5daa96531001"),
                    Name = "Indonesia", Code = "ID",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Country
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-5daa96531002"),
                    Name = "Singapura", Code = "SG",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
