using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Tax
{
    public class TaxRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Required(ErrorMessage = "Code cannot be null")]
        [StringLength(maximumLength: 1, MinimumLength = 1, ErrorMessage ="Code cannot be longer than 1 and less than 1 characther")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Required(ErrorMessage = "Rate cannot be null")]
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}
