using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Client
{
    public class AddressResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<AddressResponse> ChildData { get; set; }
    }
}
