// <copyright file="MenuResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Garuda.Modules.Common.Dtos.Responses.Details;

namespace Garuda.Modules.Common.Dtos.Responses
{
    public class MenuResponses
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string Link { get; set; }

        public MenuPermissionsResponses Permissions { get; set; }

        public List<MenuResponses> Child { get; set; }
    }
}
