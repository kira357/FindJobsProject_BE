using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels
{
    public class Pagination
    {
        public int TotalCount { get; set; }
        public int IndexPage { get; set; }
        public int PageSize { get; set; }
    }
}
