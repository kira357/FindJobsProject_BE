using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels.VMJob
{
    public class VMRecruitmentJob
    {
        public Guid Id { get; set; }

        public Guid RecruitmentId { get; set; }
        public string? CompanyOfJobs { get; set; }
        public string Name { get; set; }
        public long MajorName { get; set; }
        public string? Position { get; set; }

        public string? JobImage { get; set; }
        public string JobDetail { get; set; }

        public int Amount { get; set; }

        public string Experience { get; set; }

        public decimal SalaryMin { get; set; }

        public decimal SalaryMax { get; set; }

        public string SalaryUnit { get; set; }

        public int WorkTime { get; set; }

        public string Address { get; set; }

        public DateTimeOffset DealineForSubmission { get; set; }  

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
