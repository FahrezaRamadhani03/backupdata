using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo
{
    public class EditDevelopmentInfoRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        [Required(ErrorMessage = "ProjectId cannot be null")]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentMethod.
        /// </summary>
        [Required(ErrorMessage = "DevelopmentMethod cannot be null")]
        public string DevelopmentMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Quantity.
        /// </summary>
        [Required(ErrorMessage = "Quantity cannot be null")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DayOfSprint.
        /// </summary>
        [Required(ErrorMessage = "DayOfSprint cannot be null")]
        public string DayOfSprint { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DateTime.
        /// </summary>
        [Required(ErrorMessage = "DateTime cannot be null")]
        public DateTime KickoffDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentPeriodStart.
        /// </summary>
        [Required(ErrorMessage = "DevelopmentPeriodStart cannot be null")]
        public DateTime DevelopmentStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentPeriodEnd.
        /// </summary>
        [Required(ErrorMessage = "DevelopmentPeriodEnd cannot be null")]
        public DateTime DevelopmentEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintDates.
        /// </summary>
        [Required(ErrorMessage = "SprintDates cannot be null")]
        public List<DevelopmentSprintDateRequest> SprintDates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceLength.
        /// </summary>
        public int MaintenanceLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DayOfMaintenance.
        /// </summary>
        public DateTime? MaintenanceStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DayOfMaintenance.
        /// </summary>
        public DateTime? MaintenanceEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentMethod.
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string DevelopmentUnit { get; set; }
    }
}
