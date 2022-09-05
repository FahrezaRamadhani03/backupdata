// <copyright file="GlobalSuppressions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Visual Studio recommendation", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "This is used to prevent conflict between local variable and parameter", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "this format is used for constant", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1312:Variable names should begin with lower-case letter", Justification = "This is used to prevent conflict between local variable and parameter", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "We use swagger documentation format", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1601:Partial elements should be documented", Justification = "We use swagger documentation format", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1615:Element return value should be documented", Justification = "We use swagger documentation format", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:Documentation text should end with a period", Justification = "We use swagger documentation format", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:File should have header", Justification = "We don't need header in migration code", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:Parameter should not span multiple lines", Justification = "It's only happening in migration code", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Not needed to create new file to extract event", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Not needed", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "Order not needed", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "this not needed", Scope = "namespaceanddescendants", Target = "Garuda.Extension")]
