
using FindJobsProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FindJobsProject.Data.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        
        public string? CompanyOfJobs { get; set; }

        public string? Position { get; set; }

        [Required]
        public string JobImage { get; set; }
        [Required]
        public string JobDetail { get; set; }
        [Required]
        public int Amount { get; set; }    
        [Required]
        public String Experience { get; set; }   
        [Required]
        public decimal SalaryMin { get; set; }   
        [Required]
        public decimal SalaryMax { get; set; }  
        [Required]
        public string SalaryUnit { get; set; } 
        [Required]
        public int WorkTime { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTimeOffset DealineForSubmission { get; set; }     // Hạn cuối nộp đơn

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public IList<RecruitmentJob> RecruitmentJob { get; set; }
        public IList<CandidateJob> CandidateJob { get; set; }


    }
}
