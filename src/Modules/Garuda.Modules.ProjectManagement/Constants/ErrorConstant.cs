// <copyright file="ErrorConstant.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Modules.ProjectManagement.Constants
{
    /// <summary>
    /// Error Constant
    /// Put every single message error in here.
    /// </summary>
    public class ErrorConstant
    {
        // Untuk menampilkan Source data
        public static readonly HttpResponseLibraryException SOMETHING_WRONG = new HttpResponseLibraryException(Codes.INTERNAL_SERVER_ERROR, "Error", new MessageLangDto(null, "Something went wrong!"));

        // 400
        public static readonly HttpResponseLibraryException CLIENT_PIC_REQUIRED = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Phone number, name and client email are required"));
        public static readonly HttpResponseLibraryException PROJECT_RESOURCE_FAILED_TO_REMOVE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Project Resource failed to remove"));
        public static readonly HttpResponseLibraryException DEVELOPMENT_SCRUM_SPRINT_FAILED_TO_REMOVE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Development Scrum Sprint failed to remove"));
        public static readonly HttpResponseLibraryException CLIENT_FAILED_TO_DELETE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Client failed to deleted"));
        public static readonly HttpResponseLibraryException CLIENT_FAILED_TO_UPDATE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Client failed to deleted"));
        public static readonly HttpResponseLibraryException FILE_UPLOAD_TYPE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "File not support to upload!"));
        public static readonly HttpResponseLibraryException FILE_UPLOAD_SIZE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "File size too large or less than minimum required"));
        public static readonly HttpResponseLibraryException EXPENSE_FAILED_TO_DELETE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Expense failed to deleted"));
        public static readonly HttpResponseLibraryException BILL_FAILED_TO_DELETE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Bill failed to deleted"));
        public static readonly HttpResponseLibraryException FILE_FAILED_TO_DELETE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "File failed to deleted"));
        public static readonly HttpResponseLibraryException ACTION_STATUS_FAILED_TO_CHANGE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Project failed to change status"));
        public static readonly HttpResponseLibraryException TAX_FAILED_TO_DELETE = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Tax failed to deleted"));
        public static readonly HttpResponseLibraryException PROJECT_AMOUNT = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Project Amount must be equeal or greater than 0"));

        public static readonly HttpResponseLibraryException MAINTENANCE_LENGTH_NULL = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Maintenance Length cannot be null"));
        public static readonly HttpResponseLibraryException DEVELOPMENT_UNIT_NULL = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Development Unit cannot be null"));
        public static readonly HttpResponseLibraryException MAINTENANCE_START_NULL = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Maintenance Start cannot be null"));
        public static readonly HttpResponseLibraryException MAINTENANCE_END_NULL = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Maintenance End cannot be null"));

        public static readonly HttpResponseLibraryException ACTION_NOT_REGISTERED = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Action Not registered"));

        public static readonly HttpResponseLibraryException ADDRESS_OR_COMPANY_NAME_REQUIRED = new HttpResponseLibraryException(Codes.BAD_REQUEST, "Bad Request", new MessageLangDto(null, "Address or Company is registered if different address"));

        // 403
        public static readonly HttpResponseLibraryException FORBIDEN_ACCESS_TO_FILE_SERVER = new HttpResponseLibraryException(403, "FORBIDEN", new MessageLangDto(null, "Forbiden access to save file on server, please contact administrator!"));

        // 404
        public static readonly DataNotFoundExceptions INIT_STATE_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Init State Not Registered"));
        public static readonly DataNotFoundExceptions STATUS_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Status Not Registered"));
        public static readonly DataNotFoundExceptions RESOURCE_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Resouces Not Registered"));
        public static readonly DataNotFoundExceptions TYPE_OF_COORPORATION_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Type of Coorporation Not Registered"));
        public static readonly DataNotFoundExceptions NOT_FOUND_DEVELOPMENT_ROLES = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Development roles data not found"));
        public static readonly HttpResponseLibraryException NOT_FOUND_CLIENT = new HttpResponseLibraryException(Codes.NOT_FOUND, "Not Found", new MessageLangDto(null, "Client data Not Found"));
        public static readonly HttpResponseLibraryException TECHNOLOGY_NOT_FOUND = new HttpResponseLibraryException(Codes.NOT_FOUND, "Not Found", new MessageLangDto(null, "Technology Not Found"));
        public static readonly DataNotFoundExceptions PROJECT_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Project Not Found"));
        public static readonly DataNotFoundExceptions DEVELOPMENT_SCRUM_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Development Scrum Not Found"));
        public static readonly DataNotFoundExceptions BUDGET_ACTIVITY_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Budget Activity Not Found"));
        public static readonly DataNotFoundExceptions EXPENSE_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Expense Not Found"));
        public static readonly DataNotFoundExceptions EXPENSE_BILL_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Expense Bill Not Found"));
        public static readonly DataNotFoundExceptions BUDGET_TYPES_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Budget Types Not Found"));
        public static readonly DataNotFoundExceptions SPRINT_LIST_DATA_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Sprint list data not found"));
        public static readonly DataNotFoundExceptions PROJECT_FILE_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Project File not found"));
        public static readonly DataNotFoundExceptions TAXES_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Taxes not found"));
        public static readonly DataNotFoundExceptions TEMPLATE_HTML_NOT_FOUND = new DataNotFoundExceptions(40403, "Not Found", new MessageLangDto(null, "Template HTML not found"));

        // 409
        public static readonly HttpResponseLibraryException CONFLICT_DEVELOPMENT_ROLES = new HttpResponseLibraryException(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The code or name has been used"));
        public static readonly HttpResponseLibraryException CONFLICT_PROJECT_KEY = new HttpResponseLibraryException(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "Project Key has been used"));
        public static readonly HttpResponseLibraryException CONFLICT_ADDRESS_NAME = new HttpResponseLibraryException(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "Address Name has been added"));
        public static readonly DataConflictExeption CONFLICT_BUDGET_TYPES = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The Budget Types already exists!"));
        public static readonly DataConflictExeption CONFLICT_BUDGET_ACTIVITIES = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The Budget Activities already exists!"));
        public static readonly DataConflictExeption CONFLICT_TAX_CODES = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The Code already exists!"));
        public static readonly DataConflictExeption CONFLICT_DOCUMENT_NO = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The Proposal Number already exists!"));
        public static readonly DataConflictExeption CONFLICT_GIK_CONTRACT_NO = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The Garuda Contract Number already exists!"));
        public static readonly DataConflictExeption CONFLICT_CLIENT_CONTRACT_NO = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The Client Contract Number already exists!"));
        public static readonly DataConflictExeption CONFLICT_PAYMENT_INVOICE = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The invoice has exists!"));
        public static readonly DataConflictExeption CONFLICT_BUDGET_YEAR = new DataConflictExeption(Codes.CONFLICT, "Conflict", new MessageLangDto(null, "The budget year has exists!"));
    }
}
