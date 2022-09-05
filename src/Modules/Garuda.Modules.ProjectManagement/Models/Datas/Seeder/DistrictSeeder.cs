using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Models.Datas.Seeder
{
    public class DistrictSeeder
    {
        public static District[] Seed()
        {
            return new District[]
            {
                new District
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-7daa96531001"),
                    Name = "Sukajadi", Code = "SK",
                    CityId = new Guid("d45cb8d2-435e-4661-89d5-4daa96531001"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
                new District
                {
                    Id = new Guid("d45cb8d2-435e-4661-89d5-7daa96531002"),
                    Name = "Sukasari", Code = "GG",
                    CityId = new Guid("d45cb8d2-435e-4661-89d5-4daa96531001"),
                    CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                    CreatedBy = null,
                    DeletedBy = null,
                    UpdatedBy = null,
                },
            };
        }
    }
}
