// <copyright file="BudgetTypeSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class BudgetTypeSeeder
    {
        public static BudgetType[] Seed()
        {
            return new BudgetType[]
            {
                new BudgetType
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-1daa96531001"),
                    TypeName = "Property",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new BudgetType
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"),
                    TypeName = "Biaya SDM",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new BudgetType
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-1daa96531003"),
                    TypeName = "Prive",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new BudgetType
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"),
                    TypeName = "Biaya Operasional",
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
