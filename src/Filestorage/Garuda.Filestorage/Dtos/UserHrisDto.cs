using System;
namespace Garuda.Filestorage.Dtos
{
    public class UserHrisDto
    {
        public string EmpId { get; set; }
        public string EmpNo { get; set; }
        public string UserAd { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmpIdSuperior1st { get; set; }
        public string NameSuperior1st { get; set; }
        public string WorkLocation { get; set; }
        public string WorkLocationActual { get; set; }
        public string TitleCompany { get; set; }
        public string PositionName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string EmailOffice { get; set; }
        public int? WorkflowLevel { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminateDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? ImportDateSsis { get; set; }
        public DateTime? EndDateSsis { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string CityAddress { get; set; }
        public int? Gender { get; set; }
    }
}
