// <copyright file="LevelResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Level
{
    /// <summary>
    /// Dto for BookResponse.
    /// </summary>
    public class LevelResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Level ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Level Name
        /// </summary>
        public string Name { get; set; }
    }
}
