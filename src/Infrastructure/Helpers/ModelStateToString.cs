// <copyright file="ModelStateToString.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Garuda.Infrastructure.Helpers
{
    // To Extract Model State from POST to string
    public static class ModelStateToString
    {
        // Extract model state to stringbuilder
        public static string ExtractToString(this ModelStateDictionary data)
        {
            var resultString = string.Empty;
            foreach (var error in data.Values.SelectMany(x => x.Errors))
            {
                resultString += $"{error.ErrorMessage} \n";
            }

            return resultString;
        }
    }
}
