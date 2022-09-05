using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Client
{
    public class AddressRequest
    {
        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        public Guid? ParentId { get; set; }
    }
}
