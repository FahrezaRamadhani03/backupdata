using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Notification
{
    public class NotificationResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Messages.
        /// </summary>
        public string Message { get; set; }

        public string EmployeeName { get; set; }

        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for EmployeeName.
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Messages.
        /// </summary>
        public Guid? ProjectId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
