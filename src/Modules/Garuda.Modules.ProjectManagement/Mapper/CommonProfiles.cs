// <copyright file="CommonProfiles.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using AutoMapper;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Budget;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Tax;
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Bank;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Budget;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentHolidays;
using Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Level;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Notification;
using Garuda.Modules.ProjectManagement.Dtos.Responses.PaymentTerm;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProfitProject;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Project;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectDevelopmentTeam;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectFile;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Proposal;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Newtonsoft.Json;

namespace Garuda.Modules.ProjectManagement.Mapper
{
    /// <summary>
    /// Mapper.
    /// </summary>
    public class CommonProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonProfiles"/> class.
        /// </summary>
        public CommonProfiles()
        {
            CreateMap<DevelopmentRole, DevelopmentRoleResponses>().ReverseMap();
            CreateMap<CreateDevelopmentRoleRequest, DevelopmentRole>().ForMember(u => u.Level, opt => opt.MapFrom(r => JsonConvert.SerializeObject(r.Level))).ReverseMap();
            CreateMap<Technology, TechnologyResponses>().ReverseMap();
            CreateMap<Client, ClientResponses>()
                .ForMember(e => e.ProjectQuantity, o => o.MapFrom(x => x.ProjectDetails != null ? x.ProjectDetails.Count() : 0))
                .ReverseMap();
            CreateMap<CreateClientRequest, Client>().ReverseMap();
            CreateMap<Tax, TaxResponses>().ReverseMap();
            CreateMap<PaymentTermRequest, PaymentTerm>().ReverseMap();
            CreateMap<Level, LevelResponses>().ReverseMap();
            CreateMap<Employee, EmployeeResponses>()
                .ForMember(e => e.DeveloperRole, o => o.MapFrom(x => x.Developers.FirstOrDefault().DeveloperRoles.FirstOrDefault().DevelopmentRole.Name))
                .ForMember(e => e.DeveloperLevel, o => o.MapFrom(x => x.Developers.FirstOrDefault().DeveloperRoles.FirstOrDefault().Level.Name))
                .ForMember(e => e.Avaibility, o => o.MapFrom(x => x.Developers.FirstOrDefault().ProjectDevelopmentTeams.Count() != 0 ? "Not Available" : "Available"))
                .ForMember(e => e.ProjectCount, o => o.MapFrom(x => x.Developers.FirstOrDefault().ProjectDevelopmentTeams.Count()))
                .ReverseMap();
            CreateMap<Developer, EmployeeProjectResponses>()
                .ForMember(e => e.Name, o =>
                    o.MapFrom(s => s.ProjectDevelopmentTeams.FirstOrDefault().ProjectDetail.Name))
                .ForMember(e => e.Status, o =>
                    o.MapFrom(s => s.ProjectDevelopmentTeams.FirstOrDefault().ProjectDetail.Status))
                .ReverseMap();
            CreateMap<DeveloperRole, DeveloperRoleResponses>()
                .ForMember(e => e.Role, o =>
                    o.MapFrom(s => s.DevelopmentRole.Name))
                .ForMember(e => e.Level, o =>
                    o.MapFrom(s => s.Level.Name))
                .ReverseMap();
            CreateMap<ProjectDetail, EmployeeProjectResponses>().ReverseMap();
            CreateMap<DevelopmentTeamRole, DeveloperRoleResponses>().ReverseMap();
            CreateMap<DevelopmentTeamRequest, Developer>().ReverseMap();
            CreateMap<ScrumTeamRequest, Developer>().ReverseMap();
            CreateMap<DevelopmentTeamRequest, ProjectDevelopmentTeam>().ReverseMap();
            CreateMap<CreateProposalRequest, Proposal>().ReverseMap();
            CreateMap<CreateProposalRequest, ContractInfo>().ReverseMap();
            CreateMap<DevelopmentHoliday, DevelopmentHolidaysReponse>().ReverseMap();
            CreateMap<ProjectDetail, ProjectDetailDto>().ForMember(u => u.Technology, opt => opt.MapFrom(r => JsonConvert.DeserializeObject(r.Technology)));
            CreateMap<CreateProjectFileRequest, ProjectFile>().ReverseMap();
            CreateMap<Proposal, ProposalResponses>().ReverseMap();
            CreateMap<ProjectResources, ProjectResourcesDto>().ReverseMap();
            CreateMap<DevelopmentRole, DevelopmentRoleDto>()
                .ForMember(e => e.Code, o => o.MapFrom(x => x.Code + " " + x.ProjectResources.FirstOrDefault().Level))
                .ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ProjectDetail, PaymentTermResponses>()
                .ForMember(e => e.ProjectId, o => o.MapFrom(x => x.Id))
                .ForMember(e => e.ProjectAmount, o => o.MapFrom(x => x.Proposals.FirstOrDefault().ProjectAmount))
                .ReverseMap();
            CreateMap<PaymentTerm, PaymentTermsResponses>()
                .ForMember(e => e.Taxes, o => o.MapFrom(x => x.PaymentTermTaxes))
                .ReverseMap();
            CreateMap<PaymentTermTax, PaymentTermTaxResponses>().ReverseMap();
            CreateMap<DevelopmentHoliday, DevelopmentHolidayDto>()
                .ForMember(e => e.Name, o => o.MapFrom(x => x.Description + ", " + x.HolidayDate.ToString("dd MMM yyyy")))
                .ReverseMap();
            CreateMap<DevelopmentScrum, DevelopmentScrumDto>().ReverseMap();
            CreateMap<DevelopmentScrumSprint, DevelopmentScrumSprintDto>().ReverseMap();
            CreateMap<ProjectDetail, DevelopmentInfoDto>()
                 .ForMember(e => e.DaysOfSprint, o => o.MapFrom(x => x.DevelopmentScrums.FirstOrDefault().DaysInSprint))
                 .ForMember(e => e.Quantity, o => o.MapFrom(x => x.DevelopmentScrums.FirstOrDefault().Quantity))
                 .ForMember(e => e.SprintDates, o => o.MapFrom(x => x.DevelopmentScrums.FirstOrDefault().DevelopmentScrumSprints))
                 .ForMember(e => e.Holidays, o => o.MapFrom(x => x.DevelopmentHolidays))
                 .ForMember(e => e.DevelopmentUnit, o => o.MapFrom(x => x.MaintenanceUnit))
                 .ReverseMap();
            CreateMap<ProjectDetail, ProjectDevelopmentTeamResponses>()
                .ForMember(e => e.ProjectId, o => o.MapFrom(x => x.Id))
                .ForMember(e => e.PoDeveloper, o => o.MapFrom(x => x.ProjectScrumTeams.FirstOrDefault().PoDeveloper))
                .ForMember(e => e.SmDeveloperId, o => o.MapFrom(x => x.ProjectScrumTeams.FirstOrDefault().SmDeveloperId))
                .ReverseMap();
            CreateMap<ProjectDevelopmentTeam, DevelopmentTeamResponses>()
                .ForMember(e => e.EmployeeId, o => o.MapFrom(x => x.Developer.EmployeeId))
                .ForMember(e => e.Fullname, o => o.MapFrom(x => x.Developer.Fullname))
                .ForMember(e => e.ProjectCount, o => o.MapFrom(x => x.Developer.ProjectDevelopmentTeams.Count()))
                .ForMember(e => e.DeveloperRole, o => o.MapFrom(x => x.Developer.DeveloperRoles.FirstOrDefault().DevelopmentRole.Name))
                .ForMember(e => e.DeveloperLevel, o => o.MapFrom(x => x.Developer.DeveloperRoles.FirstOrDefault().Level.Name))
                .ReverseMap();
            CreateMap<DevelopmentTeamRole, DevelopmentTeamRoleResponses>()
                .ForMember(e => e.RoleId, o => o.MapFrom(x => x.DeveloperRole.RoleId))
                .ForMember(e => e.LevelId, o => o.MapFrom(x => x.DeveloperRole.LevelId))
                .ForMember(e => e.RoleName, o => o.MapFrom(x => x.DeveloperRole.DevelopmentRole.Name))
                .ForMember(e => e.LevelName, o => o.MapFrom(x => x.DeveloperRole.Level.Name))
                .ReverseMap();
            CreateMap<ProjectDetail, ProjectListResponses>()
                .ForMember(e => e.ProjectType, o => o.MapFrom(x => x.ClientId == null || x.ClientId == 0 ? "Internal" : "External"))
                .ReverseMap();
            CreateMap<ProjectDetail, ProjectShortInfoResponses>()
                .ForMember(e => e.ClientName, o => o.MapFrom(x => x.Client.Name))
                .ForMember(e => e.SprintQuantity, o => o.MapFrom(x => x.DevelopmentScrums.FirstOrDefault() != null ? x.DevelopmentScrums.FirstOrDefault().Quantity : 0))
                .ReverseMap();
            CreateMap<Developer, EmployeeScrumResponses>().ReverseMap();
            CreateMap<ProjectFile, ProjectFileResponses>().ReverseMap();
            CreateMap<EditProjectFileRequest, ProjectFile>().ReverseMap();
            CreateMap<Bank, BankResponses>().ReverseMap();
            CreateMap<CreateInvoiceRequest, Invoice>().ReverseMap();
            CreateMap<InvoiceDetailRequest, InvoiceDetail>().ReverseMap();
            CreateMap<ProjectDetail, ProjectInvoiceResponses>()
                .ForMember(e => e.ClientCode, o => o.MapFrom(x => x.Client.Code))
                .ForMember(e => e.ProjectName, o => o.MapFrom(x => x.Name))
                .ForMember(e => e.ProjectKey, o => o.MapFrom(x => x.Key))
                .ForMember(e => e.ProjectAmount, o => o.MapFrom(x => x.Proposals.FirstOrDefault().ProjectAmount))
                .ForMember(e => e.QtyPaid, o => o.MapFrom(x => x.Invoices.Count(x => x.Status == "PAID")))
                .ForMember(e => e.AmountPaid, o => o.MapFrom(x => x.Invoices.Where(x => x.Status == "PAID").Sum(x => x.TotalPayment)))
                .ForMember(e => e.QtyUnpaid, o => o.MapFrom(x => x.Invoices.Count(x => x.Status != "PAID")))
                .ForMember(e => e.AmountUnpaid, o => o.MapFrom(x => x.Invoices.Where(x => x.Status != "PAID").Sum(x => x.TotalPayment)))
                .ForMember(e => e.QtyOverdue, o => o.MapFrom(x => x.Invoices.Count(x => x.OverdueDate < System.DateTime.Now && x.Status != "PAID")))
                .ForMember(e => e.AmountOverdue, o => o.MapFrom(x => x.Invoices.Where(x => x.OverdueDate < System.DateTime.Now && x.Status != "PAID").Sum(x => x.TotalPayment)))
                .ReverseMap();
            CreateMap<Invoice, ProjectInvoiceDetailResponses>()
                .ForMember(e => e.SubmitDate, o => o.MapFrom(x => x.SendDate))
                .ForMember(e => e.PaymentDate, o => o.MapFrom(x => x.InvoicePayments.FirstOrDefault().PaymentDate));
            CreateMap<ProjectDetail, ProjectSieveDto>()
                .ForMember(u => u.Technology, opt => opt.MapFrom(r => JsonConvert.DeserializeObject(r.Technology)))
                .ForMember(e => e.ClientName, o => o.MapFrom(x => x.Client.Name));
            CreateMap<Client, clientTimelineDto>()
                .ForMember(e => e.ClientName, o => o.MapFrom(x => x.Name))
                .ReverseMap();
            CreateMap<Client, ClientDetailResponse>()
                 .ForMember(e => e.CompanyName, o => o.MapFrom(x => x.Name))
                 .ForMember(e => e.CompanyAddress, o => o.MapFrom(x => x.Address))
                 .ForMember(e => e.CompanyCode, o => o.MapFrom(x => x.Code))
                 .ForMember(e => e.CompanyCode, o => o.MapFrom(x => x.Code))
                 .ForMember(e => e.Province, o => o.MapFrom(x => x.State))
               .ReverseMap();
            CreateMap<ProjectDetail, ClientProjectResponse>()
                 .ForMember(e => e.Id, o => o.MapFrom(x => x.Id))
                 .ForMember(e => e.Name, o => o.MapFrom(x => x.Name))
                 .ForMember(e => e.Periode, o => o.MapFrom(x => x.DevelopmentStart != null && x.DevelopmentEnd != null ? x.DevelopmentStart.Value.ToString("dd MMM yyyy") + " - " + x.DevelopmentEnd.Value.ToString("dd MMM yyyy") : null))
                 .ForMember(e => e.Status, o => o.MapFrom(x => x.Status))
               .ReverseMap();
            CreateMap<City, AddressResponse>()
              .ForMember(e => e.ChildData, o => o.MapFrom(x => x.Districts))
              .ReverseMap();
            CreateMap<Country, AddressResponse>()
             .ForMember(e => e.ChildData, o => o.MapFrom(x => x.Provinces))
              .ReverseMap();
            CreateMap<District, AddressResponse>()
              .ReverseMap();
            CreateMap<Province, AddressResponse>()
             .ForMember(e => e.ChildData, o => o.MapFrom(x => x.Cities))
              .ReverseMap();
            CreateMap<AddressRequest, City>()
              .ForMember(e => e.ProvinceId, o => o.MapFrom(x => x.ParentId))
              .ReverseMap();
            CreateMap<AddressRequest, Country>()
              .ReverseMap();
            CreateMap<AddressRequest, District>()
             .ForMember(e => e.CityId, o => o.MapFrom(x => x.ParentId))
              .ReverseMap();
            CreateMap<AddressRequest, Province>()
             .ForMember(e => e.CountryId, o => o.MapFrom(x => x.ParentId))
              .ReverseMap();
            CreateMap<CreateProposalRequest, ProposalHistory>().ReverseMap();
            CreateMap<UpdateStatusRequest, ProjectSPK>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(e => e.ProposalNo, o => o.MapFrom(x => x.ProjectDetail.Proposals.FirstOrDefault().DocumentNo))
                .ForMember(e => e.GIKContractNo, o => o.MapFrom(x => x.ProjectDetail.ContractInfo.FirstOrDefault().GikContractNo))
                .ForMember(e => e.ClientContractNo, o => o.MapFrom(x => x.ProjectDetail.ContractInfo.FirstOrDefault().ClientContractNo))
                .ForMember(e => e.Client, o => o.MapFrom(x => x.ProjectDetail.Client.Name))
                .ReverseMap();
            CreateMap<InvoiceDetail, InvoiceDetailModel>().ReverseMap();
            CreateMap<InvoiceDetailTax, InvoiceDetailTaxModel>()
                .ForMember(e => e.Name, o => o.MapFrom(x => x.Tax.Name))
                .ReverseMap();
            CreateMap<ProjectDevelopmentTeam, ProjectDevelopmentTeamDto>().ReverseMap();
            CreateMap<Developer, EmployeeSieveDto>().ReverseMap();
            CreateMap<Expense, ExpenseDto>()
                 .ForMember(e => e.ExpenseBills, o => o.MapFrom(x => x.ExpenseBills != null ? x.ExpenseBills.Where(u => u.DeletedDate == null).ToList() : null))
                .ReverseMap();
            CreateMap<ExpenseBill, BillDto>()
                .ReverseMap();
            CreateMap<BudgetActivity, BudgetActivityDto>().ReverseMap();
            CreateMap<BudgetType, BudgetTypeDto>().ReverseMap();
            CreateMap<ProjectDetail, ProfitProjectDetail>()
                .ForMember(e => e.ProjectAmount, o => o.MapFrom(x => x.Proposals.FirstOrDefault().ProjectAmount))
                .ForMember(e => e.ProjectCost, o => o.MapFrom(x => x.Expenses.Where(x => x.DeletedDate == null).Sum(x => x.BillAmount)))
                .ReverseMap();
            CreateMap<BudgetType, BudgetTypesResponse>().ReverseMap();
            CreateMap<BudgetType, BudgetTypeDetailResponses>()
                .ForMember(e => e.TypeId, o => o.MapFrom(x => x.Id))
                .ReverseMap();
            CreateMap<Budget, BudgetResponses>().ReverseMap();
            CreateMap<Budget, BudgetResponse>().ReverseMap();
            CreateMap<BudgetRequest, Budget>().ReverseMap();
            CreateMap<BudgetDetailRequest, Budget>().ReverseMap();
            CreateMap<BudgetDetailActivityRequest, BudgetDetail>().ReverseMap();
            CreateMap<BudgetActivity, BudgetActivityDetailResponses>()
                .ForMember(e => e.Id, o => o.MapFrom(x => x.BudgetDetails != null ? x.BudgetDetails.FirstOrDefault().Id : default(Guid)))
                .ForMember(e => e.BudgetAmount, o => o.MapFrom(x => x.BudgetDetails != null ? x.BudgetDetails.FirstOrDefault().BudgetAmount : 0))
                .ForMember(e => e.BudgetPercentage, o => o.MapFrom(x => x.BudgetDetails != null ? x.BudgetDetails.FirstOrDefault().BudgetPercentage : 0))
                .ForMember(e => e.BudgetActivityId, o => o.MapFrom(x => x.Id))
                .ForMember(e => e.BudgetActivityName, o => o.MapFrom(x => x.Name))
                .ForMember(e => e.Utilized, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year).Sum(x => x.BillAmount)))
                .ForMember(e => e.January, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 1).Sum(x => x.BillAmount)))
                .ForMember(e => e.February, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 2).Sum(x => x.BillAmount)))
                .ForMember(e => e.March, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 3).Sum(x => x.BillAmount)))
                .ForMember(e => e.April, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 4).Sum(x => x.BillAmount)))
                .ForMember(e => e.May, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 5).Sum(x => x.BillAmount)))
                .ForMember(e => e.June, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 6).Sum(x => x.BillAmount)))
                .ForMember(e => e.July, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 7).Sum(x => x.BillAmount)))
                .ForMember(e => e.August, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 8).Sum(x => x.BillAmount)))
                .ForMember(e => e.September, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 9).Sum(x => x.BillAmount)))
                .ForMember(e => e.October, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 10).Sum(x => x.BillAmount)))
                .ForMember(e => e.November, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 11).Sum(x => x.BillAmount)))
                .ForMember(e => e.December, o => o.MapFrom(x => x.Expenses.Where(x => x.TransactionDate.Year == x.BudgetActivity.BudgetDetails.FirstOrDefault().Budget.Year && x.TransactionDate.Month == 12).Sum(x => x.BillAmount)))
                .ReverseMap();
            CreateMap<BudgetActivityDto, BudgetActivityResponse>().ReverseMap();
            CreateMap<TaxRequest, Tax>().ReverseMap();
            CreateMap<DevelopmentHoliday, HolidayDto>()
                .ForMember(e => e.Date, o => o.MapFrom(x => x.HolidayDate))
                .ReverseMap();
            CreateMap<Holiday, HolidayDto>()
                .ForMember(e => e.Name, o => o.MapFrom(x => x.Description + ", " + x.Date.ToString("dd MMM yyyy")))
                .ReverseMap();
            CreateMap<Notification, NotificationResponse>()
              .ForMember(e => e.ProjectName, o => o.MapFrom(x => x.Project != null ? x.Project.Name : null))
              .ForMember(e => e.EmployeeName, o => o.MapFrom(x => x.Employee != null ? x.Employee.Fullname : null))
              .ReverseMap();
        }
    }
}
