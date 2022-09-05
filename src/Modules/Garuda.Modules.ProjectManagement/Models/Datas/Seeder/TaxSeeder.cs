// <copyright file="TaxSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class TaxSeeder
    {
        public static Tax[] Seed()
        {
            return new Tax[]
            {
                new Tax
                {
                    Id = Guid.Parse("2a69de34-7b4a-4c92-8644-bd78182bb9c7"),
                    Name = "PPN",
                    Code = "T",
                    Rate = 10,
                    CreatedDate = new DateTime(2022, 04, 19, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Tax
                {
                    Id = Guid.Parse("c0327584-6c87-4db2-9c8f-a0aeba523180"),
                    Name = "PPh 23",
                    Code = "P",
                    Rate = 2,
                    CreatedDate = new DateTime(2022, 04, 19, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
