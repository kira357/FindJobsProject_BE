
using FindJobsProject.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace FindJobsProject.Database.Entities
{
    public class RecruitmentJob
    {
        public Guid RecruitmentId { get; set; }
        public AppUser Recruitments { get; set; }

        public Guid JobsId { get; set; }
        public Job Jobs { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
