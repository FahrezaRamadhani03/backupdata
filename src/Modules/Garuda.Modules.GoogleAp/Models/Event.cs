// <copyright file="Event.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.GoogleAp.Models
{
    public class Event
    {
        public string Summary { get; set; }

        public string Description { get; set; }

        public EventDateTime Start { get; set; }

        public EventDateTime End { get; set; }

        public List<Attendee> Attendees { get; set; }
    }
}
