using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Models
{
    public class Company
    {

        [Key]
       public Guid id { get; set; }
       public string name { get; set; }
        
        
       public string type { get; set; }
       public string address { get; set; }
       public string dateWork { get; set; }
       public string descriptions { get; set; }

        public bool active { get; set; }
        
        public string logo { get; set; }

        public Guid idUser { get; set; }
        virtual public User user { get; set; }
        public IList<CompanyJobs> companyJobs { get; set; }
    }
}
