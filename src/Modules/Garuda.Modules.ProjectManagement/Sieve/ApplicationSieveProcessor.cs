
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Sieve
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(IOptions<SieveOptions> options, ISieveCustomSortMethods sieveCustomSortMethods, ISieveCustomFilterMethods sieveCustomFilterMethods)
            : base(options, sieveCustomSortMethods, sieveCustomFilterMethods)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<ProjectDetailDto>(x => x.Key)
               .CanFilter()
               .CanSort();

            mapper.Property<ProjectDetailDto>(x => x.Status)
              .CanFilter()
              .CanSort();

            mapper.Property<EmployeeSieveDto>(x => x.Fullname)
             .CanFilter()
             .CanSort();

            mapper.Property<ProjectDevelopmentTeamDto>(x => x.ProjectDetail.Name)
            .CanFilter()
            .CanSort();

            return mapper;
        }

    }
}
