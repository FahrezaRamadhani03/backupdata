// <copyright file="AppConstant.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Modules.ProjectManagement.Constants
{
    public class AppConstant
    {
        // Project Action
        public const string ActDeal = "Deal";
        public const string ActHold = "Hold";
        public const string ActContinue = "Continue";
        public const string ActClose = "Close";
        public const string ActCancel = "Cancel";
        public const string ActReopen = "Reopen";
        public const string ActDone = "Done";

        // Project Status
        public const string Prospect = "Prospect";
        public const string ProposalSubmitted = "Proposal Submitted";
        public const string Preparation = "Preparation";
        public const string InProgress = "In Progress";
        public const string OnHold = "On Hold";
        public const string Canceled = "Canceled";
        public const string Maintenance = "Maintenance";
        public const string Closed = "Closed";
        public const string Done = "Done";

        public static string App = "Internal Project";

        // Subject Report
        public const string TemplateInvoice = "Template Invoice";
        public const string TemplateEmailNotSend = "Invoice is not send";
        public const string TemplateEmailNotPaid = "Invoice is not paid";

        // Invoice
        public const string Draft = "DRAFT";
        public const string Paid = "PAID";
        public const string Unpaid = "UNPAID";

        public const string Pdf = "PDF";
        public const string Excel = "EXCEL";
        public const string PPN = "PPN";
        public const string Days = "Day(s)";

        public const string Delete = "DELETE";

        // Notification
        public const string AddNewProject = " add new project ";
        public const string UpdateStatusProject = " has been updated status to ";
        public const string ChangeStatusProject = " has been changed status to ProjectStatus on project ";
        public const string UserUpdateStatusProject = "ProjectName project status has been updated to ProjectStatus by EmployeeName";
        public const string GenerateInvoiceNotification = "ProjectName has been generated new Invoice";
        public const string UpdateInvoiceNotification = "ProjectName has been updated status invoice to Status";

        // Developer Email
        public const string DeveloperAssign = "Assign To Project";

        // Timeline Color
        public const string PreparationColor = "#5382FB33";
        public const string InProgressColor = "#5A4CAF33";
        public const string MaintananceColor = "#CCCCCC33";
    }
}
