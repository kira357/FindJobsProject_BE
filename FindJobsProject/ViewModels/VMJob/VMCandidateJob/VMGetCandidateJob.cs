using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels.VMJob
{
    public class VMGetCandidateJob
    {
        public Guid IdJob { get; set; }

        public Guid IdCandicate { get; set; }

        public Guid IdRecruitment { get; set; }

        public string NameJob { get; set; }
        public string NameRecruitment { get; set; }
        public string NameCandidate { get; set; }
        public string NameMajor { get; set; }
        public string Introduction { get; set; }

        public string Resume { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateApply { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
