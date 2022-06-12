using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels.VMJob
{
    public class VMDeleteJob
    {
        public Guid IdJob { get; set; }
        public Guid IdRecruitment { get; set; }
        public string? CompanyOfJobs { get; set; }
        public string Name { get; set; }
        public long? IdMajor { get; set; }
        public string? Position { get; set; }

        public string JobImage { get; set; }
        public string JobDetail { get; set; }

        public int Amount { get; set; }

        public int Experience { get; set; }

        public decimal SalaryMin { get; set; }

        public decimal SalaryMax { get; set; }


        public int WorkTime { get; set; }

        public string Address { get; set; }

        public DateTimeOffset DateExpire { get; set; }  

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
