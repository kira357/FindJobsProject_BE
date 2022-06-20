using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.Database.Entities
{
    public class Recruitment
    {
        [Key]
        public Guid IdRecruitment { get; set; }
        public virtual AppUser User { get; set; }
        public string Logo { get; set; }
        public string NameCompany { get; set; }
        public string Summary { get; set; }
        public string Descriptions { get; set; }
        public long TypeCompany { get; set; }
        public string Address { get; set; }
        public long TypeOfWork { get; set; }
        
        public long Amount { get; set; }
    }
}
