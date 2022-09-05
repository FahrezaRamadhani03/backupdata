using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Client
{
    public class CreateClientRequest
    {
        [Required(ErrorMessage = "The Code field is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Code cannot be longer than 100 and less than 3 characther")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name cannot be longer than 50 and less than 3 characther")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        [StringLength(maximumLength: 255, ErrorMessage = "Address cannot be longer than 255 characther")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        [StringLength(maximumLength: 100, ErrorMessage = "Country cannot be longer than 100 characther")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The State field is required.")]
        [StringLength(maximumLength: 100, ErrorMessage = "State cannot be longer than 100 characther")]
        public string State { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        [StringLength(maximumLength: 100, ErrorMessage = "City cannot be longer than 100 characther")]
        public string City { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "District cannot be longer than 100 characther")]
        public string District { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "ZipCode cannot be longer than 50 and less than 2 characther")]
        public string ZipCode { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "PIC Name cannot be longer than 50 and less than 5 characther")]
        public string PICName { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 7, ErrorMessage = "PIC Phone cannot be longer than 20 and less than 7 characther")]
        public string PICPhone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "PIC Email cannot be longer than 50 and less than 5 characther")]
        public string PICEmail { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Invoice Name cannot be longer than 50 and less than 5 characther")]
        public string InvoiceName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Invoice Email Phone cannot be longer than 50 and less than 5 characther")]
        public string InvoiceEmail { get; set; }
    }
}
