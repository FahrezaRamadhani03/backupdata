using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.Common.Dtos.Responses
{
    public class PaginatedResponses<T>
        where T : class
    {
        public PaginatedResponses()
        {
            Data = new List<T>();
        }

        public int TotalData { get; set; }

        public int TotalPage { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public List<T> Data { get; set; }
    }
}
