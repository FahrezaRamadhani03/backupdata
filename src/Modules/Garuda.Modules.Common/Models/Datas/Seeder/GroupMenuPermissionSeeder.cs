// <copyright file="GroupMenuPermissionSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class GroupMenuPermissionSeeder
    {
        public static GroupMenuPermission[] Seed()
        {
            return new GroupMenuPermission[]
            {
                new GroupMenuPermission()
                    {
                        // Dashboard
                        Id = Guid.Parse("64f03301-c574-46c2-b1e6-2922eaaa826a"),
                        MenuId = Guid.Parse("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Dashboard
                        Id = Guid.Parse("b4ab5dec-b541-4a99-b998-511d093207cd"),
                        MenuId = Guid.Parse("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Create
                        Id = Guid.Parse("2259be39-3027-4aaf-b7d4-6a5d7f196c0d"),
                        MenuId = Guid.Parse("293f7746-eac8-4bd1-9550-87347467ebd2"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Create
                        Id = Guid.Parse("6607d37e-dc2b-4ea8-8de5-32bbf7d1ccd3"),
                        MenuId = Guid.Parse("293f7746-eac8-4bd1-9550-87347467ebd2"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Create Plan
                        Id = Guid.Parse("fd27fabc-218a-4163-89ee-469f38611af3"),
                        MenuId = Guid.Parse("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Create Plan
                        Id = Guid.Parse("7c5ab91a-5a1b-4b52-a643-ade5b42f862c"),
                        MenuId = Guid.Parse("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Plan Mine Closure
                        Id = Guid.Parse("246857d8-d23b-4287-9e70-bd3101ec4df8"),
                        MenuId = Guid.Parse("9f54020e-85c1-46fb-9da3-c6150a3e327b"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = true,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Plan Operation
                        Id = Guid.Parse("82ace0f9-6a4f-4a53-b524-306caf258b6d"),
                        MenuId = Guid.Parse("08d3fe57-51f3-40d7-8cbc-75899871abf2"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = true,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Plan Contractor
                        Id = Guid.Parse("2144142f-4fea-4e39-92c6-75097b01cd80"),
                        MenuId = Guid.Parse("77af2b15-1d76-489c-89b7-8f003d19acff"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = true,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Plan Mine Closure
                        Id = Guid.Parse("cf5aa817-c923-40ea-9394-de0da2335866"),
                        MenuId = Guid.Parse("9f54020e-85c1-46fb-9da3-c6150a3e327b"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = true,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Plan Operation
                        Id = Guid.Parse("77b62aa0-5794-41fb-9005-a197c50385e0"),
                        MenuId = Guid.Parse("08d3fe57-51f3-40d7-8cbc-75899871abf2"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = true,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Plan Contractor
                        Id = Guid.Parse("db5c3fdc-6d75-42a5-97bb-2a0edfbfe45a"),
                        MenuId = Guid.Parse("77af2b15-1d76-489c-89b7-8f003d19acff"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = true,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Settings
                        Id = Guid.Parse("07e87c49-180f-4f00-99e2-7322c0638a2d"),
                        MenuId = Guid.Parse("f0663ca2-ffb8-42c2-b022-38479c7c84af"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // Settings
                        Id = Guid.Parse("e59e9251-d424-4ae1-b0c7-bdd01a4a1fee"),
                        MenuId = Guid.Parse("f0663ca2-ffb8-42c2-b022-38479c7c84af"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = false,
                        CanDelete = false,
                        CanSubmit = false,
                        CanUpdate = false,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // User Management
                        Id = Guid.Parse("702e4653-2abc-41f1-86f5-c1543ab7d585"),
                        MenuId = Guid.Parse("5026c85e-04f4-4d65-9fd2-bff26ad90013"),

                        // Administrator
                        GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                        CanCreate = true,
                        CanDelete = true,
                        CanSubmit = false,
                        CanUpdate = true,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                new GroupMenuPermission()
                    {
                        // User Management
                        Id = Guid.Parse("6d8a282b-2728-4c07-a28f-93ac06977ef6"),
                        MenuId = Guid.Parse("5026c85e-04f4-4d65-9fd2-bff26ad90013"),

                        // Qpb Administrator
                        GroupId = Guid.Parse("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"),
                        CanCreate = true,
                        CanDelete = true,
                        CanSubmit = false,
                        CanUpdate = true,
                        CanView = true,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
            };
        }
    }
}
