// <copyright file="HolidaySeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class HolidaySeeder
    {
        public static Holiday[] Seed()
        {
            return new Holiday[]
            {
                new Holiday
                {
                    Id = Guid.Parse("03b7613b-3a26-4810-b6e9-59d2591115c1"),
                    Description = "Tahun Baru Masehi",
                    Date = new DateTime(2022, 01, 01, 00, 00, 00, 000),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Holiday
                {
                    Id = Guid.Parse("03b7613b-3a26-4810-b6e9-59d2591115c2"),
                    Description = "Hari Raya Nyepi",
                    Date = new DateTime(2022, 03, 03, 00, 00, 00, 000),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Holiday
                {
                    Id = Guid.Parse("03b7613b-3a26-4810-b6e9-59d2591115c3"),
                    Description = "Hari Buruh Internasional",
                    Date = new DateTime(2022, 05, 01, 00, 00, 00, 000),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
