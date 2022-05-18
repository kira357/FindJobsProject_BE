using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels.VMJob
{
    public class VMRecruitmentJob
    {
        public Guid IdJob { get; set; }

        public Guid IdRecruitment { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
