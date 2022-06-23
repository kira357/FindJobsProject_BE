using System;

namespace FindJobsProject.ViewModels.VMRecruitment
{
    public class VMCreateRecruitment
    {
        public Guid IdRecruitment { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Logo { get; set; }
        public string NameCompany { get; set; }
        public string Summary { get; set; }
        public string Descriptions { get; set; }
        public long TypeCompany { get; set; }
        public string Address { get; set; }
        public long TypeOfWork { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public long Amount { get; set; }
    }
}
