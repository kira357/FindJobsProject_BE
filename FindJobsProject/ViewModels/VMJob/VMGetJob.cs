using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.ViewModels.VMJob
{
    public class VMGetJob
    {
        public Guid IdJob { get; set; }

        [NotMapped]
        public Guid IdRecruitment { get; set; }

        public string RecruitmentName { get; set; }

        public string? CompanyOfJobs { get; set; }

        public string Name { get; set; }
        public long? idMajor { get; set; }

        public string? Position { get; set; }

        public string JobImage { get; set; }
        public string JobDetail { get; set; }

        public int Amount { get; set; }

        public string Experience { get; set; }

        public decimal SalaryMin { get; set; }

        public decimal SalaryMax { get; set; }


        public int WorkTime { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset DateExpire { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
