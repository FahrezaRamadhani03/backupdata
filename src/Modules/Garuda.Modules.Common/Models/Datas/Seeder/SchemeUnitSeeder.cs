// <copyright file="SchemeUnitSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.Common.Models.Datas.Seeder
{
    public class SchemeUnitSeeder
    {
        public static SchemeUnit[] Seed()
        {
            return new SchemeUnit[]
            {
                new SchemeUnit()
                {
                    Id = Guid.Parse("d086072c-4a06-402e-a735-11d5b034a866"),
                    UnitId = Guid.Parse("21cf75f0-c7c6-427b-a392-fce59cb50bc6"),
                    SchemeId = Guid.Parse("045a0ec7-04e9-4136-b0a6-5ef1d529ea92"),
                },
                new SchemeUnit()
                {
                    Id = Guid.Parse("8e4b6643-4b95-4051-9dc8-5fc2a2ab727f"),
                    UnitId = Guid.Parse("5b11f06f-426b-44f1-9023-170cb85797e3"),
                    SchemeId = Guid.Parse("77c9ef27-2f65-473e-8b61-ff4ce9693655"),
                },
                new SchemeUnit()
                {
                    Id = Guid.Parse("b61b1d7d-ee3c-4eae-af2b-49c0e2415449"),
                    UnitId = Guid.Parse("80f560d6-1f61-460e-95ac-ea5b9c001df5"),
                    SchemeId = Guid.Parse("5db13726-605c-4a00-b1c4-d6ce3ba507b3"),
                },
                new SchemeUnit()
                {
                    Id = Guid.Parse("51f35363-b1ef-4fbd-9021-224cf52c3bd3"),
                    UnitId = Guid.Parse("29ec8ffc-c508-4dd5-8c3d-4675ed6af4cc"),
                    SchemeId = Guid.Parse("5db13726-605c-4a00-b1c4-d6ce3ba507b3"),
                },
                new SchemeUnit()
                {
                    Id = Guid.Parse("c28fc63a-ab3b-4cfa-b246-243f35ffc552"),
                    UnitId = Guid.Parse("b1f30d87-b5a6-4fdb-9f72-76f06db7f7a5"),
                    SchemeId = Guid.Parse("5db13726-605c-4a00-b1c4-d6ce3ba507b3"),
                },
                new SchemeUnit()
                {
                    Id = Guid.Parse("842147f1-c5fa-40ce-96f0-561dda8d7ad9"),
                    UnitId = Guid.Parse("23ebbe54-45aa-4435-935d-6fad0d650b86"),
                    SchemeId = Guid.Parse("5db13726-605c-4a00-b1c4-d6ce3ba507b3"),
                },
                new SchemeUnit()
                {
                    Id = Guid.Parse("21fb0208-60a4-4827-8451-c597b54cad74"),
                    UnitId = Guid.Parse("af82ee9b-e754-4cb5-ae58-213419183dcf"),
                    SchemeId = Guid.Parse("5db13726-605c-4a00-b1c4-d6ce3ba507b3"),
                },
            };
        }
    }
}
