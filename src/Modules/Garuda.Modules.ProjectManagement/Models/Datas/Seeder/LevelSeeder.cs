// <copyright file="LevelSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class LevelSeeder
    {
        public static Level[] Seed()
        {
            return new Level[]
            {
                new Level
                {
                    Id = Guid.Parse("a1d19488-3437-42f1-beef-afe1a0518d62"),
                    Name = "Junior",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Level
                {
                    Id = Guid.Parse("e3c3dd70-e910-40b3-b2fb-8119e013b470"),
                    Name = "Middle",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Level
                {
                    Id = Guid.Parse("f7c0677f-40ba-414e-a2d8-851fd7f73b04"),
                    Name = "Senior",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
