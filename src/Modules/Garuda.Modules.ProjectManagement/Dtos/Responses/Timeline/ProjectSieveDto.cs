using System;
using System.Collections.Generic;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline
{
    public class ProjectSieveDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Client Id.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public int? ClientId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Detail.
        /// </summary>
        public clientTimelineDto Client { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Detail.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for InitState.
        /// </summary>
        public string InitState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for TypeOfCoorporation.
        /// </summary>
        public string TypeOfCoorporation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Status.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ShortDescription.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Technology.
        /// </summary>
        public List<string> Technology { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PICName.
        /// </summary>
        public string PICName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for IsRegisteredPIC.
        /// </summary>
        public bool IsRegisteredPIC { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PICPhone.
        /// </summary>
        public string PICPhone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PICEmail.
        /// </summary>
        public string PICEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentStart.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? DevelopmentStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentEnd.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? DevelopmentEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentEnd.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceStart.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? MaintenanceStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceEnd.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? MaintenanceEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectResources.
        /// </summary>
        public IList<ProjectResourcesDto> ProjectResources { get; set; } = new List<ProjectResourcesDto>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentHolidays.
        /// </summary>
        public IList<DevelopmentScrumDto> DevelopmentScrums { get; set; } = new List<DevelopmentScrumDto>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentHolidays.
        /// </summary>
        public IList<DevelopmentHolidayDto> DevelopmentHolidays { get; set; } = new List<DevelopmentHolidayDto>();
    }
}
