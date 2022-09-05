
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Notification;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class NotificationServices : INotificationServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IHubContext<NotificationHub, INotificationHub> _iNotifHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        /// <param name="iNotifHub"></param>
        public NotificationServices(
            IStorage iStorage,
            ILogger<AddressServices> iLogger,
            IMapper iMapper,
            IHubContext<NotificationHub, INotificationHub> iNotifHub
            )

        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _iNotifHub = iNotifHub;
        }

        public async Task<List<NotificationResponse>> getNotifications()
        {
            // stored procedure
            var data = await _iStorage.GetRepository<INotificationRepository>().GetData();
            var datas = _iMapper.Map<List<Notification>, List<NotificationResponse>>(data.ToList());
            return datas;
        }
    }
}
