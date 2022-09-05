// <copyright file="TimelineProjectDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Sieve.Attributes;
using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline
{
    public class TimelineProjectDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectName.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ClientId.
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ClintName.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Start_date.
        /// </summary>
        public string Start_date { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for StartDate.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for EndDate.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Duration.
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Parent.
        /// </summary>
        public int? Parent { get; set; }
    }
}
