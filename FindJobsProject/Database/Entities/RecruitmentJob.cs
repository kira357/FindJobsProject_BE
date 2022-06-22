
using FindJobsProject.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace FindJobsProject.Database.Entities
{
    public class RecruitmentJob
    {
        //public Guid IdRecruitment { get; set; }
        //public AppUser Recruitments { get; set; }      

        public Guid IdRecruitment { get; set; }
        public Recruitment Recruitments { get; set; }

        public Guid IdJob { get; set; }
        public Job Jobs { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
