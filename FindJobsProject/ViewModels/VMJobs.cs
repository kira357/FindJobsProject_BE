using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels
{
    public class VMJobs
    {
        public Guid id { get; set; }
        [NotMapped]
        public Guid idCompany { get; set; }
        public string name { get; set; }
        public string nameJobs { get; set; }
        public string Tag { get; set; }
        public string daysLeft{ get; set; }
        public string dateExpire { get; set; }
        public string descriptions { get; set; }

        public bool active { get; set; }
    }
}
