using Garuda.Modules.ProjectManagement.Dtos.Responses.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    public interface INotificationServices
    {
        /// <summary>
        /// Create Client Proviences
        /// </summary>
        /// <returns>A <see cref=""/> representing the asynchronous operation.</returns>
        Task<List<NotificationResponse>> getNotifications();
    }
}
