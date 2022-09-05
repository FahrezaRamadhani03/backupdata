// <copyright file="Event.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class Event
    {
        public Event()
        {
            this.Start = new EventDateTime()
            {
                TimeZone = "Asia/Jakarta",
            };
            this.End = new EventDateTime()
            {
                TimeZone = "Asia/Jakarta",
            };
        }

        public string Summary { get; set; }

        public string Description { get; set; }

        public EventDateTime Start { get; set; }

        public EventDateTime End { get; set; }

        public List<Attendee> Attendees { get; set; }
    }

    public class EventDateTime
    {
        public string DateTime { get; set; }

        public string TimeZone { get; set; }
    }

    public class Attendee
    {
        public string Email { get; set; }
    }
}
