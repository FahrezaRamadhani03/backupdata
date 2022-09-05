// <copyright file="MenuController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Modules.Common.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.Common.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/menus")]
    public class MenuController : Controller
    {
        private readonly IMenuServices _menuServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuController"/> class.
        /// </summary>
        /// <param name="menuServices"></param>
        public MenuController(IMenuServices menuServices)
        {
            _menuServices = menuServices;
        }
    }
}
