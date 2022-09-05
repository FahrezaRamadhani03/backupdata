using Sieve.Attributes;
using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Project
{
    /// <summary>
    /// Dto for Project List Response.
    /// </summary>
    public class ProjectListResponses
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Code { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Key { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Status { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int ClientId { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string ClientName { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Address { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? DevelopmentStart { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? DevelopmentEnd { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? MaintenanceStart { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? MaintenanceEnd { get; set; }

        public string DevelopmentPeriod { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string ProjectType { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string TypeOfCoorporation { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime CreatedDate { get; set; }
    }
}
