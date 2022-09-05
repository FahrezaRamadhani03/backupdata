// <copyright file="DevelopmentRoleSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class DevelopmentRoleSeeder
    {
        public static DevelopmentRole[] Seed()
        {
            return new DevelopmentRole[]
            {
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531001"), Name = "Project manager", Code = "PM", Leader = true, Level = null, CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531002"), Name = "Acting Project Manager", Code = "APM", Leader = true, Level = null, CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531003"), Name = "Technical Leader", Code = "TL", Leader = true, Level = null, CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"), Name = "Frontend Developer", Code = "FE", Leader = false, Level = "[\"Senior\",  \"Middle\",  \"Junior\"]", CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"), Name = "Backend Developer", Code = "BE", Leader = false, Level = "[\"Senior\",  \"Middle\",  \"Junior\"]", CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"), Name = "Mobile Developer", Code = "MBL", Leader = false, Level = "[\"Senior\",  \"Middle\",  \"Junior\"]", CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"), Name = "Business Analyst", Code = "BA", Leader = false, Level = "[\"Senior\",  \"Middle\",  \"Junior\"]", CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"), Name = "System Analyst", Code = "SA", Leader = false, Level = "[\"Senior\",  \"Middle\",  \"Junior\"]", CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
                new DevelopmentRole
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"), Name = "Quality Assurance", Code = "QA", Leader = false, Level = "[\"Senior\",  \"Middle\",  \"Junior\"]", CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000), CreatedBy = null, DeletedBy = null, UpdatedBy = null,
                },
            };
        }
    }
}
