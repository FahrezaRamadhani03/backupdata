// <copyright file="GroupSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class GroupSeeder
    {
        public static Group[] Seed()
        {
            return new Group[]
            {
                new Group()
                    {
                        Id = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        Name = "Administrator",
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new Group()
                    {
                        Id = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        Name = "QPB Administrator",
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new Group()
                    {
                        Id = Guid.Parse("fa997ce4-5b76-447c-9b08-5f448f185ad3"),
                        Name = "Mine Head",
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
            };
        }
    }
}
