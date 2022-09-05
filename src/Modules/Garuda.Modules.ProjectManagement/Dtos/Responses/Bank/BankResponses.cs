// <copyright file="BankResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Bank
{
    public class BankResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Bank ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Bank Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Bank Name
        /// </summary>
        public string Name { get; set; }
    }
}
