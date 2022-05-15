using FindJobsProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FindJobsProject.Data.Entities
{
    public class CandidateJob
    {
        public string Introduction { get; set; }

        public string Resume { get; set; }

        public Guid CandicateId { get; set; }
        public AppUser Candicate { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public Guid RecruitmentId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
