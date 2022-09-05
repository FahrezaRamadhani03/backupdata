// <copyright file="MenuPermissionsResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Modules.Common.Dtos.Responses.Details
{
    public class MenuPermissionsResponses
    {
        public bool CanView { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanCreate { get; set; }

        public bool CanDelete { get; set; }

        public bool CanSubmit { get; set; }
    }
}
