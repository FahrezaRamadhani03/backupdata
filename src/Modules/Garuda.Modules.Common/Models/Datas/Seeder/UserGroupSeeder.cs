// <copyright file="UserGroupSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class UserGroupSeeder
    {
        public static UserGroup[] Seed()
        {
            return new UserGroup[]
            {
                 new UserGroup()
                 {
                     Id = Guid.Parse("e5c455f1-f239-4f29-bebd-8bc4239e15fb"),
                     UserId = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
                 new UserGroup()
                 {
                     Id = Guid.Parse("ec211d37-2400-4877-8696-62ac17faeecb"),
                     UserId = Guid.Parse("2446aa92-3c84-4072-8c5e-d8c41deac9c4"),
                     GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
                 new UserGroup()
                 {
                     Id = Guid.Parse("f1a56c59-0128-4799-826d-50ce44921cb6"),
                     UserId = Guid.Parse("2446aa92-3c84-4072-8c5e-d8c41deac9c4"),
                     GroupId = Guid.Parse("fa997ce4-5b76-447c-9b08-5f448f185ad3"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
                 new UserGroup()
                 {
                     Id = Guid.Parse("4b894dac-7e06-4891-8498-6521ba85dcac"),
                     UserId = Guid.Parse("8b3c44cb-244b-4f13-b2a0-22020ae26bc6"),
                     GroupId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
                 new UserGroup()
                 {
                     Id = Guid.Parse("145e7f39-120c-4cdd-baac-fbbd74b72a69"),
                     UserId = Guid.Parse("8b3c44cb-244b-4f13-b2a0-22020ae26bc6"),
                     GroupId = Guid.Parse("fa997ce4-5b76-447c-9b08-5f448f185ad3"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
                 new UserGroup()
                 {
                     Id = Guid.Parse("10195c34-4e6d-4795-bbde-bbd17e2c1b0b"),
                     UserId = Guid.Parse("b5a93e5d-e159-4c69-b90d-ae3239a692d3"),
                     GroupId = Guid.Parse("fa997ce4-5b76-447c-9b08-5f448f185ad3"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
                 new UserGroup()
                 {
                     Id = Guid.Parse("d050c114-fc5f-45c8-a736-b0cacdfc47e6"),
                     UserId = Guid.Parse("b5a93e5d-e159-4c69-b90d-ae3239a692d3"),
                     GroupId = Guid.Parse("1CE881EB-4AE2-4B04-83D9-7062E6CFFFD5"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
                 new UserGroup()
                 {
                     Id = Guid.Parse("fe9b8375-2bab-4449-88a1-efe80155054e"),
                     UserId = Guid.Parse("b5a93e5d-e159-4c69-b90d-ae3239a692d3"),
                     GroupId = Guid.Parse("9EE09365-B140-4BC0-A5A1-79098DDBEED7"),
                     CreatedBy = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                     CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                 },
            };
        }
    }
}
