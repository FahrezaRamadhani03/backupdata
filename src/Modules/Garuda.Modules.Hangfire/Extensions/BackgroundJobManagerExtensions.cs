// <copyright file="BackgroundJobManagerExtensions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Hangfire.Contracts;

namespace Garuda.Modules.Hangfire.Extensions
{
    /// <summary>
    /// Some extension methods for <see cref="IBackgroundJobManager"/>.
    /// </summary>
    public static class BackgroundJobManagerExtensions
    {
        /// <summary>
        /// Enqueues a job to be executed.
        /// </summary>
        /// <typeparam name="TArgs">Type of the arguments of job.</typeparam>
        /// <param name="backgroundJobManager">Background job manager reference</param>
        /// <param name="args">Job arguments.</param>
        /// <param name="delay">Job delay (wait duration before first try).</param>
        public static string Enqueue<TArgs>(this IBackgroundJobManager backgroundJobManager, TArgs args, TimeSpan? delay = null)
        {
            return AsyncHelper.RunSync(() => backgroundJobManager.EnqueueAsync(args, delay));
        }
    }
}
