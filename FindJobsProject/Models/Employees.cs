using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Models
{
    public class Employees
    {
        [Key]
        public Guid Id { get; set; }
        public string NameEmployee { get; set; }
        public string PostionEmployee { get; set; }
        
        public string email { get; set;  }
        public string address { get; set; }

        virtual public User user { get; set; }

        
    }
}
