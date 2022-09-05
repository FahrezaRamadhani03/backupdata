using System;
using System.Collections.Generic;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Project
{
    /// <summary>
    /// Dto for Project Short Info Response.
    /// </summary>
    public class ProjectShortInfoResponses
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Code { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Status { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int ClientId { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string ClientName { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? DevelopmentStart { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? DevelopmentEnd { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? MaintenanceStart { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? MaintenanceEnd { get; set; }

        public string DevelopmentPeriod { get; set; }

        public string MaintenancePeriod { get; set; }

        public string CurrentSprint { get; set; }

        public int? SprintQuantity { get; set; }

        public string PeriodeSprint { get; set; }

        public List<string> Holidays { get; set; }

        public string Technology { get; set; }

        public string InitState { get; set; }

        public string RequiredResources { get; set; }

        public List<ProjectDevTeamResponses> DevelopmentTeams { get; set; }
    }
}
