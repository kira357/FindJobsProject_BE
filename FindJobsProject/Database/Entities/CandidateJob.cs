using FindJobsProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FindJobsProject.Data.Entities
{
    public class CandidateJob
    {
        public Guid IdCandicate { get; set; }
        public AppUser Candicate { get; set; }
        public Guid IdJob { get; set; }
        public Job Job { get; set; }
        public Guid IdRecruitment { get; set; }
        public string Introduction { get; set; }
        public string Resume { get; set; }
        public bool IsActive { get; set; }
        public bool IsPending { get; set; }
        public bool IsDelete { get; set; }
        public DateTimeOffset DateApply { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

    }
}
