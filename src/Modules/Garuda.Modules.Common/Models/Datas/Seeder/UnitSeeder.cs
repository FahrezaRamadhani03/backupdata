// <copyright file="UnitSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class UnitSeeder
    {
        public static Unit[] Seed()
        {
            return new Unit[]
            {
                new Unit()
                {
                    Id = Guid.Parse("80f560d6-1f61-460e-95ac-ea5b9c001df5"),
                    Name = "IMM",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Unit()
                {
                    Id = Guid.Parse("23ebbe54-45aa-4435-935d-6fad0d650b86"),
                    Name = "Melak",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Unit()
                {
                    Id = Guid.Parse("b1f30d87-b5a6-4fdb-9f72-76f06db7f7a5"),
                    Name = "KTD EMB",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Unit()
                {
                    Id = Guid.Parse("21cf75f0-c7c6-427b-a392-fce59cb50bc6"),
                    Name = "TRUST",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Unit()
                {
                    Id = Guid.Parse("29ec8ffc-c508-4dd5-8c3d-4675ed6af4cc"),
                    Name = "JBG",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Unit()
                {
                    Id = Guid.Parse("5b11f06f-426b-44f1-9023-170cb85797e3"),
                    Name = "KTD TDM",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
                new Unit()
                {
                    Id = Guid.Parse("af82ee9b-e754-4cb5-ae58-213419183dcf"),
                    Name = "GPK",
                    CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                },
            };
        }
    }
}
