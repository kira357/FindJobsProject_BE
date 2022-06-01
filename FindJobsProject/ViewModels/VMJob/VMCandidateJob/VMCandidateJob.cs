using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels.VMJob
{
    public class VMCandidateJob
    {
        public Guid IdJob { get; set; }

        public Guid IdCandicate { get; set; }

        public Guid IdRecruitment { get; set; }
        public string Introduction { get; set; }

        public string Resume { get; set; }

        [NotMapped]
        public IFormFile FileApply { get; set; }
        public bool IsActive { get; set; }
        public bool IsPending { get; set; }
        public bool IsDelete { get; set; }

        public DateTimeOffset DateApply { get; set; }  

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
