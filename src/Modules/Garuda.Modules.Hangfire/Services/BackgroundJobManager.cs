// <copyright file="BackgroundJobManager.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Modules.Hangfire.Configurations;
using Garuda.Modules.Hangfire.Contracts;
using Garuda.Modules.Hangfire.Models;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Serilog;

namespace Garuda.Modules.Hangfire.Services
{
    public class BackgroundJobManager : IBackgroundJobManager
    {
        public ILogger<BackgroundJobManager> Logger { protected get; set; }

        protected BackgroundJobCollection Jobs { get; }

        protected IServiceScopeFactory ServiceScopeFactory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundJobManager"/> class.
        /// </summary>
        /// <param name="jobs"></param>
        /// <param name="serviceScopeFactory"></param>
        public BackgroundJobManager(
            BackgroundJobCollection jobs,
            IServiceScopeFactory serviceScopeFactory)
        {
            Logger = NullLogger<BackgroundJobManager>.Instance;
            ServiceScopeFactory = serviceScopeFactory;
            Jobs = jobs;
        }

        /// <inheritdoc />
        public Task<string> EnqueueAsync<TArgs>(TArgs args, TimeSpan? delay = null, DateTimeOffset? enqueueAt = null)
        {
            if (delay.HasValue && enqueueAt.HasValue)
            {
                throw new ArgumentException($"{nameof(delay)} and {nameof(enqueueAt)} can't have both values.");
            }

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                string jobId;
                var jobType = Jobs.GetJob(typeof(TArgs)).JobType;
                var job = (IBackgroundJob<TArgs>)scope.ServiceProvider.GetService(jobType);
                if (job == null)
                {
                    throw new Exception("The job type is not registered to DI: " + jobType);
                }

                try
                {
                    if (delay.HasValue)
                    {
                        jobId = BackgroundJob.Schedule(() => job.Execute(args), delay.Value);
                    }
                    else if (enqueueAt.HasValue)
                    {
                        jobId = BackgroundJob.Schedule(() => job.Execute(args), enqueueAt.Value);
                    }
                    else
                    {
                        jobId = BackgroundJob.Enqueue(() => job.Execute(args));
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, $"Failed executing job {GetType().Name}: {ex.Message}");
                    throw;
                }

                return Task.FromResult(jobId);
            }
        }
    }
}
