// <copyright file="Extension.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Models;

namespace Garuda.Database.Abstract
{
    /// <summary>
    /// Overrides the <see cref="ExtensionBase">ExtensionBase</see> class and provides the ExtCore.Data extension information.
    /// </summary>
    public class Extension : ExtensionBase
    {
        /// <summary>
        /// Gets the name of the extension.
        /// </summary>
        public override string Name => "Garuda.Database";

        /// <summary>
        /// Gets the URL of the extension.
        /// </summary>
        public override string Url => "https://www.garudainfinity.com/";

        /// <summary>
        /// Gets the version of the extension.
        /// </summary>
        public override string Version => "5.1.0";

        /// <summary>
        /// Gets the authors of the extension (separated by commas).
        /// </summary>
        public override string Authors => "Garuda";
    }
}