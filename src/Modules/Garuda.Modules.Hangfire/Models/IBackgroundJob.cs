// <copyright file="IBackgroundJob.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Modules.Hangfire.Models
{
    /// <summary>
    /// Defines interface of a background job.
    /// </summary>
    public interface IBackgroundJob<in TArgs>
    {
        /// <summary>
        /// Executes the job with the <see cref="args"/>.
        /// </summary>
        /// <param name="args">Job arguments.</param>
        void Execute(TArgs args);
    }
}
