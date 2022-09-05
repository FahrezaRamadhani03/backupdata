// <copyright file="CitySeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class CitySeeder
    {
        public static City[] Seed()
        {
            return new City[]
            {
                new City
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-4daa96531001"),
                    Name = "Bandung", Code = "BDG",
                    ProvinceId = new Guid("d45cb8d2-435e-4661-89d5-6daa96531001"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new City
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-4daa96531002"),
                    Name = "Tegal", Code = "TGL",
                    ProvinceId = new Guid("d45cb8d2-435e-4661-89d5-6daa96531002"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
