using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace Garuda.Modules.ProjectManagement.Hubs
{
    public class NotificationHub : Hub<INotificationHub>
    {
        private readonly IStorage _iStorage;
        private readonly INotificationServices _notifService;

        public NotificationHub(IStorage iStorage, INotificationServices notifService)
        {
            _iStorage = iStorage;
            _notifService = notifService;
        }

        public async Task SendMessage(Notification message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public async Task GetMessages()
        {
            var data = await _notifService.getNotifications();

            await Clients.All.ReceiveMessage(data);
        }
    }
}
