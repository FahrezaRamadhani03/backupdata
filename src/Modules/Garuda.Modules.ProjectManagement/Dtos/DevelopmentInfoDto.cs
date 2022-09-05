using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class DevelopmentInfoDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentMethod.
        /// </summary>
        public string DevelopmentMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DaysOfSprint.
        /// </summary>
        public string DaysOfSprint { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for KickoffDate.
        /// </summary>
        public DateTime? KickoffDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentStart.
        /// </summary>
        public DateTime? DevelopmentStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentEnd.
        /// </summary>
        public DateTime? DevelopmentEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintDates.
        /// </summary>
        public IList<DevelopmentScrumSprintDto> SprintDates { get; set; } = new List<DevelopmentScrumSprintDto>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Holidays.
        /// </summary>
        public IList<DevelopmentHolidayDto> Holidays { get; set; } = new List<DevelopmentHolidayDto>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceLength.
        /// </summary>
        public int MaintenanceLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceStart.
        /// </summary>
        public DateTime? MaintenanceStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceEnd.
        /// </summary>
        public DateTime? MaintenanceEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentUnit.
        /// </summary>
        public string DevelopmentUnit { get; set; }
    }
}
