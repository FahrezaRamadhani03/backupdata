// <copyright file="InvoiceServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Email.Actions;
using Garuda.Modules.Email.Constants;
using Garuda.Modules.Email.Contracts;
using Garuda.Modules.Email.Models.Contracts;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice;
using Garuda.Modules.ProjectManagement.Helper;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly IConfiguration _configuration;
        private readonly IConverter _converter;
        private readonly IEmailSender _emailSender;
        private readonly IRazorRendererHelper _razorRendererHelper;
        private readonly AdditionalEmailConfiguration _additionalEmail = new AdditionalEmailConfiguration();
        private readonly IHubContext<NotificationHub, INotificationHub> _notifHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="sieve"></param>
        /// <param name="iconfiguration"></param>
        /// <param name="converter"></param>
        /// <param name="emailSender"></param>
        /// <param name="razorRendererHelper"></param>
        /// <param name="additionalEmail"></param>
        /// <param name="notifHub"></param>
        public InvoiceServices(
            IStorage iStorage,
            ILogger<InvoiceServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve,
            IConfiguration iconfiguration,
            IConverter converter,
            IEmailSender emailSender,
            IRazorRendererHelper razorRendererHelper,
            IOptions<AdditionalEmailConfiguration> additionalEmail,
            IHubContext<NotificationHub, INotificationHub> notifHub)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
            _configuration = iconfiguration;
            _converter = converter;
            _emailSender = emailSender;
            _razorRendererHelper = razorRendererHelper;
            _additionalEmail = additionalEmail.Value;
            _notifHub = notifHub;
        }

        public async Task<MessageDto> GetAllList(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Trying to get menu data..");
                var invoices = await _iStorage.GetRepository<IProjectDetailRepository>().GetAllInvoices();
                if (invoices.Count() > 0)
                {
                    var datas = _iMapper.Map<List<ProjectDetail>, List<ProjectInvoiceResponses>>(invoices.ToList());
                    var sieveData = _sieve.Apply(sieveModel, datas.AsQueryable());
                    var result = new PaginatedResponses<ProjectInvoiceResponses>()
                    {
                        Data = sieveData.ToList(),
                        TotalData = datas.Count(),
                        TotalPage = (int)Math.Ceiling((double)datas.Count() / sieveModel.PageSize.Value),
                        CurrentPage = sieveModel.Page.Value,
                        PageSize = sieveModel.PageSize.Value,
                    };
                    if (result.Data.Count == 0)
                    {
                        return new MessageDto(Codes.NOT_FOUND, "Not Found", SuccessConstant.NOT_FOUND, null, new List<ProjectInvoiceResponses>());
                    }
                    else
                    {
                        return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_INVOICES, null, result);
                    }
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", SuccessConstant.NOT_FOUND, null, new List<ProjectInvoiceResponses>());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> Create(CreateInvoiceRequest model)
        {
            try
            {
                // validation input user
                // validate paymentId
                if (model.PaymentTermId != null)
                {
                    // if invoice is exists throw error
                    _iLogger.LogInformation("Check invoice..");
                    if (!await _iStorage.GetRepository<IPaymentTermRepository>().IsPaymentTermHasInvoice((Guid)model.PaymentTermId) && model.Id == null)
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_PAYMENT_INVOICE;
                    }
                }

                if (model.IsDifferentAddress)
                {
                    if (model.BillingAddress == null && model.CompanyName == null)
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.ADDRESS_OR_COMPANY_NAME_REQUIRED;
                    }
                }

                _iLogger.LogInformation("Getting user data from database..");
                var newInvoice = _iMapper.Map<CreateInvoiceRequest, Invoice>(model);
                foreach (var detail in model.InvoiceDetail)
                {
                    newInvoice.DiscountTotal += detail.Discount;
                }

                decimal totalTax = 0;
                if (model.TaxDetail != null)
                {
                    foreach (var tax in model.TaxDetail)
                    {
                        totalTax += tax.Amount;
                    }
                }

                if (model.IsAdditionalDiscount == true)
                {
                    newInvoice.TotalPayment = newInvoice.Subtotal - newInvoice.DiscountTotal - model.AdditionalDiscount + totalTax;
                }
                else
                {
                    newInvoice.TotalPayment = newInvoice.Subtotal - newInvoice.DiscountTotal + totalTax;
                }

                var paymentTerm = new PaymentTerm { };

                var projectDetail = await _iStorage.GetRepository<IProjectDetailRepository>().GetById((Guid)model.ProjectId);

                if (model.PaymentTermId != null)
                {
                    paymentTerm = await _iStorage.GetRepository<IPaymentTermRepository>().GetData((Guid)model.PaymentTermId);
                    GenerateDocument generate = new GenerateDocument();
                    var doc = generate.GenerateInvoiceNumber(projectDetail.Key, 0);
                    paymentTerm.InvoiceId = newInvoice.Id;
                    newInvoice.InvoiceNo = doc.StrDocNo;
                    await _iStorage.GetRepository<IPaymentTermRepository>().AddOrUpdate(paymentTerm);
                }
                else
                {
                    GenerateDocument generate = new GenerateDocument();
                    var termNo = await _iStorage.GetRepository<IProjectDetailRepository>().GetLastInvoicesNo(projectDetail.Id);
                    var doc = generate.GenerateInvoiceNumber(projectDetail.Key, termNo + 1);
                    newInvoice.InvoiceNo = doc.StrDocNo;
                }

                if (newInvoice.OverdueUnit == AppConstant.Days)
                {
                    newInvoice.OverdueDate = newInvoice.InvoiceDate.AddDays(newInvoice.OverdueLength);
                }
                else
                {
                    newInvoice.OverdueDate = newInvoice.InvoiceDate.AddMonths(newInvoice.OverdueLength);
                }

                if (model.Id == null)
                {
                    newInvoice.Status = AppConstant.Draft;
                }
                else
                {
                    newInvoice.Status = model.Status;
                }

                if (!model.IsDifferentAddress)
                {
                    newInvoice.BillingAddress = projectDetail.Client?.Address;
                    newInvoice.CompanyName = projectDetail.Client?.Name;
                }

                _iLogger.LogInformation("Saving new invoice to database..");
                await _iStorage.GetRepository<IInvoiceRepository>().AddOrUpdate(newInvoice);

                // Delete existing detail data
                if (model.Id != null)
                {
                    var registeredDetail = await _iStorage.GetRepository<IInvoiceDetailRepository>().GetRegisteredInvoiceByInvoiceId((Guid)model.Id);
                    foreach (var detail in registeredDetail)
                    {
                        if (!model.InvoiceDetail.Any(u => u.Id == detail) && !model.InvoiceDetail.Any(u => u.Id == Guid.Empty))
                        {
                            await _iStorage.GetRepository<IInvoiceDetailRepository>().Delete((Guid)detail);
                        }
                    }

                    await _iStorage.SaveAsync();
                }

                var invoiceDetail = _iMapper.Map<List<InvoiceDetailRequest>, List<InvoiceDetail>>(model.InvoiceDetail);
                foreach (var newInvoiceDetail in invoiceDetail)
                {
                    newInvoiceDetail.InvoiceId = newInvoice.Id;
                    await _iStorage.GetRepository<IInvoiceDetailRepository>().AddOrUpdate(newInvoiceDetail);
                }

                if (model.TaxDetail != null)
                {
                    foreach (var tax in model.TaxDetail)
                    {
                        var taxDetail = new InvoiceDetailTax()
                        {
                            InvoiceId = newInvoice.Id,
                            TaxId = tax.TaxId,
                            TaxRate = tax.Rate,
                            TaxAmount = tax.Amount,
                        };
                        await _iStorage.GetRepository<IInvoiceDetailTaxRepository>().AddOrUpdate(taxDetail);
                    }
                }

                await _iStorage.SaveAsync();

                await GenerateInvoice(newInvoice.Id);

                await SendProjectNotification(paymentTerm.ProjectId, projectDetail.Name, null, AppConstant.GenerateInvoiceNotification);

                return new MessageDto("Create or modified invoice success");
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Trying to create payment has been failed, with err:", ex);
                throw;
            }
        }

        public async Task<MessageDto> GetData(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Trying to get menu data..");
                var invoices = await _iStorage.GetRepository<IInvoiceRepository>().GetData(id);
                if (invoices != null)
                {
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_INVOICES, null, invoices);
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", SuccessConstant.NOT_FOUND, null, new Invoice());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> Delete(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Trying to delete menu data..");
                await _iStorage.GetRepository<IInvoiceRepository>().Delete(id);
                await _iStorage.SaveAsync();
                return new MessageDto("Data has been deleted successfully");
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> SendInvoice(SendInvoiceRequest model)
        {
            try
            {

                _iLogger.LogInformation("Saving sent invoice to database..");

                await _iStorage.GetRepository<IInvoiceRepository>().SendInvoice(model);

                await _iStorage.SaveAsync();

                // send notification to all client
                var (projectId, projectName) = await _iStorage.GetRepository<IInvoiceRepository>().GetProjectDataByInvoiceId(model.InvoiceId);

                await SendProjectNotification(projectId, projectName, AppConstant.Unpaid, AppConstant.UpdateInvoiceNotification);
                return new MessageDto("Invoice has been sent");
            }
            catch (DataNotFoundExceptions ex)
            {
                throw new DataNotFoundExceptions();
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> SetPaid(InvoicePaymentRequest model)
        {
            try
            {

                _iLogger.LogInformation("Saving paid invoice to database..");

                await _iStorage.GetRepository<IInvoiceRepository>().SetPaid(model.InvoiceId);

                var invoicePayment = new InvoicePayment()
                {
                    InvoiceId = model.InvoiceId,
                    BankId = model.BankId,
                    PaymentAmount = model.PaymentAmount,
                    Remarks = model.Remarks,
                    PaymentDate = model.PaymentDate,
                    AccountName = model.AccountName,
                };
                await _iStorage.GetRepository<IInvoicePaymentRepository>().AddOrUpdate(invoicePayment);

                await _iStorage.SaveAsync();

                // send notification to all client
                var (projectId, projectName) = await _iStorage.GetRepository<IInvoiceRepository>().GetProjectDataByInvoiceId(model.InvoiceId);

                await SendProjectNotification(projectId, projectName, AppConstant.Paid, AppConstant.UpdateInvoiceNotification);

                return new MessageDto("Invoice has been paid");
            }
            catch (DataNotFoundExceptions ex)
            {
                throw new DataNotFoundExceptions();
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetStatusInvoice()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching status data..");
                var datas = _configuration.GetSection("StatusInvoice").Get<List<StatusInvoiceDto>>();
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");
                return new MessageDto(
                    Infrastructure.Constants.Codes.SUCCESS,
                    "Found",
                    null,
                    SuccessConstant.FOUND_STATUS_INVOICE,
                    datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching status data, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task CronJobSendEmailInvoiceNotSend()
        {
            var template = await _iStorage.GetRepository<Email.Models.Contracts.ITemplateEmailRepository>().GetData(AppConstant.TemplateEmailNotSend);
            if (string.Equals(_additionalEmail.EmailEnvironment.ToLower(), EmailEnvironmentConstant.DEVELOPMENT.ToLower()))
            {
                var email = _configuration.GetSection("EmailCOO").Value;
                var invoices = await _iStorage.GetRepository<IInvoiceRepository>().GetData();
                foreach (var invoice in invoices)
                {
                    if (invoice.Status != AppConstant.Paid && invoice.OverdueDate >= DateTime.Now)
                    {
                        var link = _configuration.GetSection("AppURL").Value + $"/api/invoices/download?{invoice.Id}";
                        var body = string.Format(template.Body, invoice.InvoiceNo, link);
                        await _emailSender.SendEmailAsync(email.ToString(), template.Subject, body, true);
                    }
                }
            }
            else
            {
                var emails = new List<string>();
                emails.AddRange(_additionalEmail.EmailToMembers);
                foreach (var email in emails)
                {
                    var invoices = await _iStorage.GetRepository<IInvoiceRepository>().GetData();
                    foreach (var invoice in invoices)
                    {
                        if (invoice.Status != AppConstant.Paid && invoice.OverdueDate >= DateTime.Now)
                        {
                            var link = _configuration.GetSection("AppURL").Value + $"/api/invoices/download?{invoice.Id}";
                            var body = string.Format(template.Body, invoice.InvoiceNo, link);
                            await _emailSender.SendEmailAsync(email.ToString(), template.Subject, body, true);
                        }
                    }
                }
            }
        }

        public async Task CronJobSendEmailInvoiceNotPaid()
        {
            var template = await _iStorage.GetRepository<Email.Models.Contracts.ITemplateEmailRepository>().GetData(AppConstant.TemplateEmailNotPaid);
            if (string.Equals(_additionalEmail.EmailEnvironment.ToLower(), EmailEnvironmentConstant.DEVELOPMENT.ToLower()))
            {
                var email = _configuration.GetSection("EmailCOO").Value;
                var invoices = await _iStorage.GetRepository<IInvoiceRepository>().GetData();
                foreach (var invoice in invoices)
                {
                    if (invoice.Status != AppConstant.Paid && invoice.OverdueDate >= DateTime.Now)
                    {
                        var link = _configuration.GetSection("AppURL").Value + $"/api/invoices/download?{invoice.Id}";
                        var body = string.Format(template.Body, invoice.InvoiceNo, link);
                        await _emailSender.SendEmailAsync(email.ToString(), template.Subject, body, true);
                    }
                }
            }
            else
            {
                var emails = new List<string>();
                emails.AddRange(_additionalEmail.EmailToMembers);
                foreach (var email in emails)
                {
                    var invoices = await _iStorage.GetRepository<IInvoiceRepository>().GetData();
                    foreach (var invoice in invoices)
                    {
                        if (invoice.Status != AppConstant.Paid && invoice.OverdueDate >= DateTime.Now)
                        {
                            var link = _configuration.GetSection("AppURL").Value + $"/api/invoices/download?{invoice.Id}";
                            var body = string.Format(template.Body, invoice.InvoiceNo, link);
                            await _emailSender.SendEmailAsync(email.ToString(), template.Subject, body, true);
                        }
                    }
                }
            }
        }

        public async Task CronJobGenerateInvoice()
        {
            try
            {
                var paymentTerms = await _iStorage.GetRepository<IPaymentTermRepository>().GetDataByUnpaid();
                foreach (var paymentTerm in paymentTerms)
                {
                    var projectDetail = await _iStorage.GetRepository<IProjectDetailRepository>().GetById(paymentTerm.ProjectId);

                    GenerateDocument generate = new GenerateDocument();
                    var termNo = await _iStorage.GetRepository<IProjectDetailRepository>().GetLastInvoicesNo(paymentTerm.ProjectId);
                    var doc = generate.GenerateInvoiceNumber(projectDetail.Key, termNo + 1);
                    if (paymentTerm.ReminderDate.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
                    {
                        decimal taxAmount = 0;
                        foreach (var detailTax in paymentTerm.PaymentTermTaxes)
                        {
                            var tax = await _iStorage.GetRepository<ITaxRepository>().GetData(detailTax.TaxId);
                            taxAmount += paymentTerm.Amount * tax.Rate / 100;
                        }

                        var invoice = new Invoice()
                        {
                            AdditionalDiscount = 0,
                            DiscountTotal = 0,
                            InvoiceDate = paymentTerm.InvoiceDate,
                            InvoiceNo = doc.StrDocNo,
                            IsAdditionalDiscount = false,
                            OverdueDate = DateTime.Now.AddDays(3),
                            OverdueLength = 3,
                            OverdueUnit = AppConstant.Days,
                            PaymentTermId = paymentTerm.Id,
                            ProjectId = paymentTerm.ProjectId,
                            Remarks = null,
                            ReminderDate = DateTime.Now.AddDays(3),
                            Status = AppConstant.Draft,
                            TotalPayment = paymentTerm.Amount + taxAmount,
                            Subtotal = paymentTerm.Amount + taxAmount,
                            BillingAddress = projectDetail?.Client?.Address,
                            CompanyName = projectDetail?.Client?.Name,
                        };
                        await _iStorage.GetRepository<IInvoiceRepository>().AddOrUpdate(invoice);

                        var invoiceDetail = new InvoiceDetail()
                        {
                            Description = $"Pembayaran invoice ke-{paymentTerm.TermNo} {paymentTerm.Title}",
                            Discount = 0,
                            InvoiceId = invoice.Id,
                            Price = paymentTerm.Amount,
                            Quantity = 1,
                            Subtotal = paymentTerm.Amount,
                        };
                        await _iStorage.GetRepository<IInvoiceDetailRepository>().AddOrUpdate(invoiceDetail);

                        foreach (var detailTax in paymentTerm.PaymentTermTaxes)
                        {
                            var tax = await _iStorage.GetRepository<ITaxRepository>().GetData(detailTax.TaxId);
                            var invoiceTax = new InvoiceDetailTax()
                            {
                                InvoiceId = invoice.Id,
                                TaxId = detailTax.TaxId,
                                TaxRate = tax.Rate,
                                TaxAmount = paymentTerm.Amount * tax.Rate / 100,
                            };
                            await _iStorage.GetRepository<IInvoiceDetailTaxRepository>().AddOrUpdate(invoiceTax);
                        }

                        paymentTerm.InvoiceId = invoice.Id;
                        await _iStorage.GetRepository<IPaymentTermRepository>().AddOrUpdate(paymentTerm);

                        await _iStorage.SaveAsync();

                        await GenerateInvoice(invoice.Id);

                        await SendProjectNotification(paymentTerm.ProjectId, projectDetail.Name, null, AppConstant.GenerateInvoiceNotification);
                    }
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching status data, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<(string path, string contextType, string fileName)> DownloadInvoiceAsync(Guid id)
        {
            var invoice = await _iStorage.GetRepository<IInvoiceRepository>().GetData(id);
            var fileNaame = invoice.Filename + ".pdf";
            var fileDate = fileNaame.Substring(fileNaame.LastIndexOf('-') + 1, 6);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "media", "invoice", fileDate, fileNaame);

            FileInfo fileInfo = new FileInfo(path);
            var fileExt = fileInfo.Extension;

            string contextType = FileHelper.GetFileContextType(fileExt);
            string savedFileName = fileNaame.Substring(fileNaame.IndexOf('-') + 1);
            savedFileName = savedFileName.Substring(0, savedFileName.LastIndexOf("-")) + fileExt;

            return (path, contextType, savedFileName);
        }

        private async Task<(byte[], string fileName)> GenerateInvoice(Guid id)
        {
            try
            {
                var invoice = await _iStorage.GetRepository<IInvoiceRepository>().GetData(id);
                var invoiceViewModel = _iMapper.Map<InvoiceViewModel>(invoice);
                var template = await _iStorage.GetRepository<ITemplateReportRepository>().GetData(AppConstant.TemplateInvoice);

                var logo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Image" + Path.DirectorySeparatorChar + "logo-gik.png";

                var htmlContent = new StringBuilder();
                htmlContent.Append(@" " + template.Head);
                htmlContent.AppendFormat(
                    @" " + template.Body,
                    "'" + logo + "'",
                    invoiceViewModel.InvoiceNo,
                    invoiceViewModel.ProposalNo,
                    invoiceViewModel.InvoiceDate.ToString("dd MMMM yyyy"),
                    invoiceViewModel.OverdueDate.ToString("dd MMMM yyyy"),
                    invoiceViewModel.GIKContractNo,
                    invoiceViewModel.ClientContractNo,
                    invoiceViewModel.Client,
                    invoiceViewModel.ClientAddress,
                    invoiceViewModel.ClientCity);

                foreach (var detail in invoiceViewModel.InvoiceDetails)
                {
                    htmlContent.AppendFormat(
                        @" " + template.BodyDetail,
                        detail.No,
                        detail.Description,
                        detail.Quantity,
                        detail.Price,
                        detail.Discount,
                        detail.Subtotal);
                }

                decimal ppnAmount = 0;
                decimal pphAmoun = 0;
                foreach (var tax in invoiceViewModel.InvoiceDetailTaxes)
                {
                    if (tax.Name == AppConstant.PPN)
                    {
                        ppnAmount = tax.TaxAmount;
                    }
                    else
                    {
                        pphAmoun = tax.TaxAmount;
                    }
                }

                htmlContent.AppendFormat(
                    @" " + template.Footer,
                    invoiceViewModel.Subtotal,
                    invoiceViewModel.DiscountTotal,
                    invoiceViewModel.AdditionalDiscount,
                    ppnAmount,
                    pphAmoun,
                    invoiceViewModel.TotalPayment,
                    invoiceViewModel.AdditionalNote);

                var projectDetail = await _iStorage.GetRepository<IProjectDetailRepository>().GetById((Guid)invoice.ProjectId);
                var paymentTerm = new PaymentTerm();
                if (invoice.PaymentTermId != null)
                {
                    paymentTerm = await _iStorage.GetRepository<IPaymentTermRepository>().GetData((Guid)invoice.PaymentTermId);
                }

                var fileName = string.Empty;
                if (paymentTerm != null)
                {
                    var termNo = paymentTerm.TermNo.ToString("D2");
                    fileName = "INV-" + projectDetail.Key + "-" + termNo + "-1-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    fileName = "INV-" + projectDetail.Key + "-00-1-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }

                var path = GeneratePdf(htmlContent.ToString(), fileName);

                invoice.Filename = fileName;
                await _iStorage.GetRepository<IInvoiceRepository>().AddOrUpdate(invoice);
                var history = new InvoiceFileHistory()
                {
                    InvoiceId = invoice.Id,
                    Filename = fileName,
                };
                await _iStorage.GetRepository<IInvoiceFileHistoryRepository>().AddOrUpdate(history);

                await _iStorage.SaveAsync();

                return (path, fileName);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Generate Invoice, err : {ex}");
                throw ex;
            }
        }

        private byte[] GeneratePdf(string htmlContent, string fileName)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 18, Bottom = 18 },
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 10, Right = "Page [page] of [toPage]", Line = false },
                FooterSettings = { FontSize = 11, Center = "© Garuda Infinity Kreasindo - www.garudainfinity.com", Line = false },
            };

            var htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };

            var newDirectory = Path.Combine(Directory.GetCurrentDirectory(), "media", "invoice", DateTime.Now.Date.ToString("yyyyMM"));
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            File.WriteAllBytes(newDirectory + Path.DirectorySeparatorChar + fileName + ".pdf", _converter.Convert(htmlToPdfDocument));

            return _converter.Convert(htmlToPdfDocument);
        }

        private async Task SendProjectNotification(Guid projectId, string projectName, string projectStatus, string action)
        {
            try
            {
                // send notification to client
                _iLogger.LogInformation($"Create notification");
                var message = action.Replace("ProjectName", projectName);
                if (projectStatus != null)
                {
                    message = message.Replace("Status", projectStatus);
                }

                var notif = new Notification
                {
                    Message = message,
                    ProjectId = projectId,
                    EmployeeId = null,
                };
                await _iStorage.GetRepository<INotificationRepository>().AddOrUpdate(notif);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Send notification to all client");
                await _notifHub.Clients.All.ReceiveMessage(new Notification
                {
                    Id = notif.Id,
                    Message = notif.Message,
                    ProjectId = notif.ProjectId,
                    EmployeeId = null,
                });
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Send notification to all client failed with err: ", ex);
            }
        }
    }
}