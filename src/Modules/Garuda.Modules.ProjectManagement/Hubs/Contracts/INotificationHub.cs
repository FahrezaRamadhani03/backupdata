using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Notification;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Hubs.Contracts
{
    public interface INotificationHub
    {
        Task ReceiveMessage(Notification message);

        Task ReceiveMessage(List<NotificationResponse> messages);

        Task GetMessages(List<Notification> messages);
    }
}
