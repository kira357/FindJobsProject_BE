using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels.VMJob
{
    public class VMUpdateCandidateJob
    {
        public Guid IdJob { get; set; }

        public Guid IdCandicate { get; set; }

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
