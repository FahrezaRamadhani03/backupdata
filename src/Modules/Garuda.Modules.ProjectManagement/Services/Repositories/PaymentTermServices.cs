// <copyright file="PaymentTermServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Email.Actions;
using Garuda.Modules.GoogleAp.Models;
using Garuda.Modules.GoogleAp.Services.Contracts;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;
using Garuda.Modules.ProjectManagement.Dtos.Responses.PaymentTerm;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class PaymentTermServices : IPaymentTermServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IGoogleCalendarSender _iGoogleCalendarSender;
        private readonly SieveProcessor _sieve;
        private readonly AdditionalEmailConfiguration _additionalEmail = new AdditionalEmailConfiguration();

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentTermServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iGoogleCalendarSender"></param>
        /// <param name="sieve"></param>
        /// <param name="additionalEmail"></param>
        public PaymentTermServices(
            IStorage iStorage,
            ILogger<PaymentTermServices> iLogger,
            IMapper iMapper,
            IGoogleCalendarSender iGoogleCalendarSender,
            SieveProcessor sieve,
            IOptions<AdditionalEmailConfiguration> additionalEmail)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _iGoogleCalendarSender = iGoogleCalendarSender;
            _sieve = sieve;
            _additionalEmail = additionalEmail.Value;
        }

        public async Task<MessageDto> CreatePaymentTerms(CreatePaymentTermRequest model)
        {
            try
            {
                _iLogger.LogInformation("Saving new payment term to database..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().FindById(model.ProjectId);
                project.OverdueLength = model.OverdueLength;
                project.OverdueUnit = model.OverdueUnit;
                await _iStorage.GetRepository<IProjectDetailRepository>().AddOrUpdate(project);

                foreach (var data in model.PaymentTerms)
                {
                    if ((data.Status == null ? null : data.Status.ToUpper()) != AppConstant.Delete)
                    {
                        var paymentTerm = _iMapper.Map<PaymentTermRequest, PaymentTerm>(data);
                        paymentTerm.ProjectId = model.ProjectId;
                        await _iStorage.GetRepository<IPaymentTermRepository>().AddOrUpdate(paymentTerm);

                        foreach (var taxes in data.Taxes)
                        {
                            var paymentTermTax = new PaymentTermTax()
                            {
                                PaymentTermId = paymentTerm.Id,
                                TaxId = taxes.TaxId,
                            };

                            await _iStorage.GetRepository<IPaymentTermTaxRepository>().AddOrUpdate(paymentTermTax);
                        }
                    }
                    else
                    {
                        await _iStorage.GetRepository<IPaymentTermRepository>().Delete((Guid)data.Id);
                    }

                    var emails = new List<string>();
                    emails.AddRange(_additionalEmail.EmailToMembers);

                    var attendees = new List<Attendee>();

                    foreach (var email in emails)
                    {
                        var attendee = new Attendee() { Email = email };
                        attendees.Add(attendee);
                    }

                    var days = (data.InvoiceDate - data.ReminderDate).TotalDays;
                    for (int i = 0; i <= days; i++)
                    {
                        var date = default(DateTime);
                        if (i == 0)
                        {
                            date = data.ReminderDate;
                        }
                        else
                        {
                            date = data.ReminderDate.AddDays(i);
                        }

                        var client = project.Client == null ? "Internal" : project.Client.Name;

                        var events = new Event()
                        {
                            Summary = $"Reminder Pembayaran Invoice {project.Name}-{client}-Invoice ke-{data.TermNo} {data.Title}",
                            Description = $"Invoice akan segera di generate untuk project {project.Name} {client}, mohon cek di invoice list dan harus ditagihkan ke client sebelum tanggal {data.InvoiceDate.ToString("dd MMMM yyyy")}.",
                            End = new EventDateTime
                            {
                                DateTime = date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                                TimeZone = "Asia/Jakarta",
                            },
                            Start = new EventDateTime
                            {
                                DateTime = date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                                TimeZone = "Asia/Jakarta",
                            },
                            Attendees = attendees,
                        };

                        _ = _iGoogleCalendarSender.CreateEvent(events);
                    }
                }

                await _iStorage.SaveAsync();

                return new MessageDto("Create or modified payment term success");
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

        public async Task<MessageDto> GetPaymentTermByProjectId(Guid projectId)
        {
            try
            {
                _iLogger.LogInformation("Getting data list employee..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetPaymentTermbyProjectId(projectId);
                if (project != null)
                {
                    var data = _iMapper.Map<ProjectDetail, PaymentTermResponses>(project);
                    _iLogger.LogInformation($"Data has been fetched. with data");
                    return new MessageDto(Codes.SUCCESS, "Found", "Payment terms is Found", null, data);
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Data Not Found", null, new PaymentTermResponses());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetPaymentTermByUnpaid(Guid projectId)
        {
            try
            {
                _iLogger.LogInformation("Trying to get menu data..");
                var paymentTerms = await _iStorage.GetRepository<IPaymentTermRepository>().GetDataByUnpaid(projectId);
                if (paymentTerms.Count() > 0)
                {
                    return new MessageDto(Codes.SUCCESS, "Found", "Payment terms is Found", null, paymentTerms.ToList());
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Payment terms is Found", null, new List<PaymentTerm>());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }
    }
}
