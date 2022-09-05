// <copyright file="MenuServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Contracts;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Dtos.Responses.Details;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Garuda.Modules.Common.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.Common.Services.Repositories
{
    public class MenuServices : IMenuServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IJwtFactory _iJwtFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iJwtFactory"></param>
        public MenuServices(
            IStorage iStorage,
            ILogger<MenuServices> iLogger,
            IMapper iMapper,
            IJwtFactory iJwtFactory)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _iJwtFactory = iJwtFactory;
        }

        public async Task<List<MenuResponses>> GetMenu(HttpContext context)
        {
            var session = await _iJwtFactory.GetSession(context);
            var menus = new List<MenuResponses>();

            _iLogger.LogInformation("Trying to get menu data..");
            var parents = await _iStorage.GetRepository<IMenuRepository>().GetData(true, session.UserId);

            _iLogger.LogInformation($"Data has been fetched. with {parents.Count} data");
            foreach (var parent in parents)
            {
                var item = await Map(parent);
                menus.Add(item);
            }

            return menus;
        }

        private async Task<MenuResponses> Map(Menu menuItem)
        {
            var item = new MenuResponses
            {
                Name = menuItem.DisplayName,
                Link = menuItem.Slug,
                Icon = menuItem.IconClass,
                Permissions = _iMapper.Map<GroupMenuPermission, MenuPermissionsResponses>(menuItem.GroupMenuPermissions.FirstOrDefault(x => x.MenuId == menuItem.Id)),
            };

            _iLogger.LogInformation("Trying to get menu data..");
            var childItems = await _iStorage.GetRepository<IMenuRepository>().GetData(menuItem.Id, true);
            foreach (var childItem in childItems)
            {
                var childMenu = await Map(childItem);
                if (item.Child == null)
                {
                    item.Child = new List<MenuResponses>();
                }

                item.Child.Add(childMenu);
            }

            return item;
        }
    }
}
