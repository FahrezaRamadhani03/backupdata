// <copyright file="ApplicationSieveProcessor.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Infrastructure.Sieves
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(IOptions<SieveOptions> options, ISieveCustomSortMethods sieveCustomSortMethods, ISieveCustomFilterMethods sieveCustomFilterMethods)
            : base(options, sieveCustomSortMethods, sieveCustomFilterMethods)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            return mapper;
        }
    }
}
