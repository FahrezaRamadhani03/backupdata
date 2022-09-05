// <copyright file="LdapLibraryItem.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Database.Ldap.Configurations
{
    public class LdapLibraryItem
    {
        /// <summary>
        /// Gets or sets for Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets for Domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets for SearchBase.
        /// </summary>
        public string SearchBase { get; set; }

        /// <summary>
        /// Gets or sets for SearchFilter.
        /// </summary>
        public string SearchFilter { get; set; }
    }
}
