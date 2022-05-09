using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Models
{
    public class Jobs
    {

        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string Tag {get;set;}

        public string dateExpire { get; set; }
        public string daysLeft { get; set; }
        public string descriptions { get; set; }

        public bool active { get; set; }
        public IList<CompanyJobs> companyJobs { get; set; }
    }
}
