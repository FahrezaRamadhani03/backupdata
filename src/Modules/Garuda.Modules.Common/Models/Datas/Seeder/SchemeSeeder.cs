// <copyright file="SchemeSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class SchemeSeeder
    {
        public static Scheme[] Seed()
        {
            return new Scheme[]
            {
                new Scheme()
                {
                    Id = Guid.Parse("045a0ec7-04e9-4136-b0a6-5ef1d529ea92"),
                    Name = "Contractor",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Scheme()
                {
                    Id = Guid.Parse("77c9ef27-2f65-473e-8b61-ff4ce9693655"),
                    Name = "Mine Closure",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Scheme()
                {
                    Id = Guid.Parse("5db13726-605c-4a00-b1c4-d6ce3ba507b3"),
                    Name = "Operation",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
            };
        }
    }
}
