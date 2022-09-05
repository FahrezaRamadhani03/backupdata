using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Client
{
    /// <summary>
    /// Dto for Client Response.
    /// </summary>
    public class ClientResponses
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public int Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Code { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Country { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string State { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string City { get; set; }

        public string District { get; set; }

        public string ZipCode { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string PICName { get; set; }

        public string PICPhone { get; set; }

        public string PICEmail { get; set; }

        public int ProjectQuantity { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
