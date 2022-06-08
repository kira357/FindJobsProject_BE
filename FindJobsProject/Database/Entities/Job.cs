
using FindJobsProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FindJobsProject.Data.Entities
{
    public class Job
    {
        public Guid IdJob { get; set; }

        public string? CompanyOfJobs { get; set; }

        public string Name { get; set; }

        public long? IdMajor { get; set; }

        public string? Position { get; set; }

        public string JobImage { get; set; }
        [Required]
        public string JobDetail { get; set; }
        [Required]
        public int Amount { get; set; }    
        [Required]
        public string? Experience { get; set; }   
        [Required]
        public decimal SalaryMin { get; set; }   
        [Required]
        public decimal SalaryMax { get; set; }  
        [Required]
        public int WorkTime { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTimeOffset DateExpire { get; set; }     // Hạn cuối nộp đơn

        public long? TypeJob { get; set; } 

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        public IList<RecruitmentJob> RecruitmentJobTable { get; set; }
        public IList<FavoritesJobs> Favorites { get; set; }

        public IList<CandidateJob> CandidateJob { get; set; }


    }
}
