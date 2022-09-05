// <copyright file="LdapLibraryConfig.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Garuda.Database.Ldap.Configurations
{
    public class LdapLibraryConfig
    {
        public LdapLibraryDefaultUser DefaultUser { get; set; }

        /// <summary>
        /// Gets or sets for LdapLibraryItems.
        /// </summary>
        public List<LdapLibraryItem> LdapLibraryItems { get; set; }
    }
}
