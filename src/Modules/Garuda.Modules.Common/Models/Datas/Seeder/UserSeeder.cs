// <copyright file="UserSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class UserSeeder
    {
        public static User[] Seed()
        {
            return new User[]
            {
                    new User
                    {
                        Id = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        Email = "system@system.co",
                        IsActive = true,
                        Username = "systemadmin",
                        Password = "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO",
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                        Fullname = "System",
                    },
                    new User
                    {
                        Id = Guid.Parse("fa3876d9-b8ce-4029-9df6-2e8ee94a3d78"),
                        Email = "systemreserve@system.co",
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                        IsActive = true,
                        Username = "systemadminreserve",
                        Password = "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO",
                        Fullname = "System Admin Reserve",
                    },
            };
        }
    }
}
