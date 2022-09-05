using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class DevelopmentScrumSprintDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Sprintname.
        /// </summary>
        public string Sprintname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintStart.
        /// </summary>
        public DateTime SprintStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintEnd.
        /// </summary>
        public DateTime SprintEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DayLength.
        /// </summary>
        public int DayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for HolidayLength.
        /// </summary>
        public int HolidayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remark.
        /// </summary>
        public string Remark { get; set; }
    }
}
