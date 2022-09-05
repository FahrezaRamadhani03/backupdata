// <copyright file="BaseModel.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Infrastructure.Models
{
    public class BaseModel
    {
        public Guid? CreatedBy { get; set; } = Guid.Empty;

        public DateTime? CreatedDate { get; set; }

        public Guid? UpdatedBy { get; set; } = Guid.Empty;

        public DateTime? UpdatedDate { get; set; }

        public Guid? DeletedBy { get; set; } = Guid.Empty;

        public DateTime? DeletedDate { get; set; }
    }
}
