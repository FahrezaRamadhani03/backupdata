
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Dashboard;
using Garuda.Modules.ProjectManagement.Models.Repositories;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class DashboardServices : IDashboardServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        /// <param name="iconfiguration"></param>
        public DashboardServices(
           IStorage iStorage,
           ILogger<DashboardServices> iLogger,
           IConfiguration configuration,
           IMapper iMapper)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _configuration = configuration;
        }

        public async Task<MessageDto> GetProjectSummary()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching project data..");
                var projects = await _iStorage.GetRepository<ProjectDetailRepository>().GetData(true);

                var status = _configuration.GetSection("StatusProject").Get<List<StatusDto>>();

                var resultSummary = new List<ProjectSummaryResponse> { };
                int total = 0;
                foreach (var stat in status)
                {
                    resultSummary.Add(new ProjectSummaryResponse
                    {
                        Status = stat.Name,
                        Count = 0,
                    });
                    foreach (var project in projects)
                    {
                        if (project.Status == stat.Name)
                        {
                            var index = resultSummary.FindIndex(u => u.Status == project.Status);
                            resultSummary[index].Count++;
                            total++;
                        }
                    }
                }

                // total summary
                resultSummary.Add(new ProjectSummaryResponse
                {
                    Status = "Total",
                    Count = total,
                });
                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT_SUMMARY, resultSummary);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching project, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetRecentProject()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching project data..");
                var recentUpdatedProjects = await _iStorage.GetRepository<ProjectDetailRepository>().GetDatabyLastUpdate();
                var recentCreatedProjects = await _iStorage.GetRepository<ProjectDetailRepository>().GetDatabyCreated();

                var last5Created = recentCreatedProjects.GetRange(0, 5);
                var last5updated = recentUpdatedProjects.GetRange(0, 5);
                var result = new List<RecentProjectResponse> { };
                foreach (var project in last5Created)
                {
                    result.Add(new RecentProjectResponse
                    {
                        Id = project.Id,
                        Name = project.Name,
                        PeriodDate = project.DevelopmentStart?.ToString("dd MMM yyyy") + " - " + project.DevelopmentEnd?.ToString("dd MMM yyyy"),
                        Status = project.Status,
                        KickOffDate = project.KickoffDate?.ToString("dd MMM yyyy"),
                        LastModified = project.CreatedDate,
                    });
                }

                foreach (var project in last5updated)
                {
                    result.Add(new RecentProjectResponse
                    {
                        Id = project.Id,
                        Name = project.Name,
                        PeriodDate = project.DevelopmentStart?.ToString("dd MMM yyyy") + " - " + project.DevelopmentEnd?.ToString("dd MMM yyyy"),
                        Status = project.Status,
                        KickOffDate = project.KickoffDate?.ToString("dd MMM yyyy"),
                        LastModified = project.UpdatedDate,
                    });
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_RECENT_PROJECT, result.OrderByDescending(u => u.LastModified).Take(5).ToList());
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching project, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetRecentProjectInvoice()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching project data..");
                var projects = await _iStorage.GetRepository<ProjectDetailRepository>().GetInvoices();
                var projectInvoice = new List<InvoiceResponse> { };
                foreach (var project in projects)
                {
                    foreach (var invoce in project.Invoices)
                    {
                        projectInvoice.Add(new InvoiceResponse
                        {
                            Id = project.Id,
                            Name = project.Client.Name,
                            StatusInvoice = invoce.Status,
                            Invoice = invoce.InvoiceNo,
                            InvoiceDate = invoce.InvoiceDate.ToString("dd MMM yyyy"),
                        });
                    }
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_RECENT_INVOICE, projectInvoice);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching project, err : {ex}");
                throw;
            }
        }
    }
}
