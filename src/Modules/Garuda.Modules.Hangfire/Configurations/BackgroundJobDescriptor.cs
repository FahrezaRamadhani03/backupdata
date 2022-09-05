// <copyright file="BackgroundJobDescriptor.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.Hangfire.Configurations
{
    public class BackgroundJobDescriptor
    {
        public BackgroundJobDescriptor(Type jobType)
        {
            JobType = jobType;
            ArgsType = BackgroundJobArgsHelper.GetJobArgsType(jobType);
            JobName = JobType.FullName;
        }

        public Type ArgsType { get; }

        public Type JobType { get; }

        public string JobName { get; }
    }
}
