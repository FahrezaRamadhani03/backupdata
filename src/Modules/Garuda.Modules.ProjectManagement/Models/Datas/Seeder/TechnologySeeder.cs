// <copyright file="TechnologySeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class TechnologySeeder
    {
        public static Technology[] Seed()
        {
            return new Technology[]
            {
                new Technology
                {
                    Id = Guid.Parse("03b7613b-3a26-4810-b6e9-59d2591115c6"),
                    Name = "Vue",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Technology
                {
                    Id = Guid.Parse("4ac682e1-bb55-4432-98f6-a392ad922183"),
                    Name = "Node Js",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new Technology
                {
                    Id = Guid.Parse("ec1698a2-1ba0-4b47-8c49-24470e231122"),
                    Name = "React",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
