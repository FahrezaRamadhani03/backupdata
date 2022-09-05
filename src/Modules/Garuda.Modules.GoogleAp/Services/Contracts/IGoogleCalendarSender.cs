// <copyright file="IGoogleCalendarSender.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.GoogleAp.Models;

namespace Garuda.Modules.GoogleAp.Services.Contracts
{
    /// <summary>
    /// GoogleCalendarSender contract services.
    /// </summary>
    public interface IGoogleCalendarSender : IServiceRepository
    {
        /// <summary>
        /// Connection to Google Calendar API.
        /// </summary>
        /// <returns>A <see cref="string"/> representing the asynchronous operation.</returns>
        MessageDto Redirect();

        /// <summary>
        /// Connection to Google Calendar API.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="error"></param>
        /// <param name="state"></param>
        void Callback(string code, string error, string state);

        /// <summary>
        /// Connection to Google Calendar API.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MessageDto> RefreshToken();

        /// <summary>
        /// Connection to Google Calendar API.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        MessageDto RevokeToken();

        /// <summary>
        /// Connection to Google Calendar API.
        /// </summary>
        /// <param name="calendarEvent"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateEvent(Event calendarEvent);
    }
}
