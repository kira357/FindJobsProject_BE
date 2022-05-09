using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Models
{
    public class CompanyJobs
    {
        public Guid companyId { get; set; }
        public Company company { get; set; }

        public Guid jobsId { get; set; }
        public Jobs jobs { get; set; }
    }
}
