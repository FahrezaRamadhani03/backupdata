// <copyright file="MenuSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class MenuSeeder
    {
        public static Menu[] Seed()
        {
            return new Menu[]
            {
                    new Menu()
                    {
                        Id = Guid.Parse("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"),
                        ParentId = Guid.Empty,
                        IconClass = "icon-home",
                        Code = "dash",
                        DisplayName = "Dashboard",
                        Level = 0,
                        Slug = "/Dashboard",
                        DisplayOrder = 0,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("293f7746-eac8-4bd1-9550-87347467ebd2"),
                        ParentId = Guid.Empty,
                        IconClass = "icon-add",
                        Code = "cr",
                        DisplayName = "Create",
                        Level = 0,
                        Slug = string.Empty,
                        DisplayOrder = 1,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"),
                        ParentId = Guid.Parse("293f7746-eac8-4bd1-9550-87347467ebd2"),
                        IconClass = string.Empty,
                        Code = "cp",
                        DisplayName = "Create Plan",
                        Level = 1,
                        Slug = string.Empty,
                        DisplayOrder = 0,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("9f54020e-85c1-46fb-9da3-c6150a3e327b"),
                        ParentId = Guid.Parse("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"),
                        IconClass = string.Empty,
                        Code = "cp",
                        DisplayName = "Plan Mine Closure",
                        Level = 2,
                        Slug = "/CreatePlanMineClosure",
                        DisplayOrder = 0,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("08d3fe57-51f3-40d7-8cbc-75899871abf2"),
                        ParentId = Guid.Parse("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"),
                        IconClass = string.Empty,
                        Code = "cp",
                        DisplayName = "Plan Operation",
                        Level = 2,
                        Slug = "/CreatePlanOperation",
                        DisplayOrder = 1,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("77af2b15-1d76-489c-89b7-8f003d19acff"),
                        ParentId = Guid.Parse("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"),
                        IconClass = string.Empty,
                        Code = "cp",
                        DisplayName = "Plan Contractor",
                        Level = 2,
                        Slug = "/CreatePlanContractor",
                        DisplayOrder = 2,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("6906ffec-78d6-4631-977d-b0375351fb70"),
                        ParentId = Guid.Parse("293f7746-eac8-4bd1-9550-87347467ebd2"),
                        IconClass = "icon-add",
                        Code = "cr",
                        DisplayName = "Create Actual",
                        Level = 1,
                        Slug = string.Empty,
                        DisplayOrder = 1,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("77118193-d70c-4e36-97a0-683b9e825569"),
                        ParentId = Guid.Empty,
                        IconClass = "icon-notes",
                        Code = "act",
                        DisplayName = "My Activity",
                        Level = 0,
                        Slug = string.Empty,
                        DisplayOrder = 2,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("7f2302be-efd5-43f1-b6c9-8e8886c8460c"),
                        ParentId = Guid.Empty,
                        IconClass = "icon-file",
                        Code = "doc",
                        DisplayName = "My Document",
                        Level = 0,
                        Slug = string.Empty,
                        DisplayOrder = 3,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("d73f2bc0-8b65-46f2-9e06-9bd52e990283"),
                        ParentId = Guid.Empty,
                        IconClass = "icon-search",
                        Code = "doclib",
                        DisplayName = "Document Library",
                        Level = 0,
                        Slug = string.Empty,
                        DisplayOrder = 4,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("806f809b-cdd3-4591-a553-085ac97037b9"),
                        ParentId = Guid.Parse("d73f2bc0-8b65-46f2-9e06-9bd52e990283"),
                        IconClass = string.Empty,
                        Code = "vplan",
                        DisplayName = "View Plan",
                        Level = 1,
                        Slug = string.Empty,
                        DisplayOrder = 0,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("049dde67-5798-4e74-8fff-503400311161"),
                        ParentId = Guid.Parse("d73f2bc0-8b65-46f2-9e06-9bd52e990283"),
                        IconClass = string.Empty,
                        Code = "vact",
                        DisplayName = "View Actual",
                        Level = 1,
                        Slug = string.Empty,
                        DisplayOrder = 1,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                        ParentId = Guid.Empty,
                        IconClass = "icon-cog-outline",
                        Code = "set",
                        DisplayName = "Profile",
                        Level = 0,
                        Slug = string.Empty,
                        DisplayOrder = 5,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
                    new Menu()
                    {
                        Id = Guid.Parse("5026c85e-04f4-4d65-9fd2-bff26ad90013"),
                        ParentId = Guid.Parse("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                        IconClass = "icon-user",
                        Code = "user",
                        DisplayName = "User Management",
                        Level = 1,
                        Slug = "/IndexUser",
                        DisplayOrder = 0,
                        CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                        CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    },
            };
        }
    }
}
