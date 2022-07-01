using FindJobsProject.ViewModels.VMJob;
using System;
using System.Collections.Generic;

namespace FindJobsProject.ViewModels.VMRecruitment
{
    public class VMGetRecruitment
    {
        public Guid IdRecruitment { get; set; }
        public string Logo { get; set; }
        public string UrlLogo { get; set; }
        public string NameCompany { get; set; }
        public string Summary { get; set; }
        public string Descriptions { get; set; }
        public long TypeCompany { get; set; }
        public string Address { get; set; }
        public long TypeOfWork { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public long Amount { get; set; }

        public int JobInCompany { get; set; }

        public int CountJob { get; set; }

        public ICollection<VMGetJob> vMJobs { get; set; }
    }
}
