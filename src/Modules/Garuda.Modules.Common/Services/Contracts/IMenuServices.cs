// <copyright file="IMenuServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Datas;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.Common.Services.Contracts
{
    /// <summary>
    /// Menu contract services
    /// </summary>
    public interface IMenuServices
    {
        /// <summary>
        /// Get Menu by User Id
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A <see cref="MenuResponses"/> representing the asynchronous operation.</returns>
        Task<List<MenuResponses>> GetMenu(HttpContext context);
    }
}
