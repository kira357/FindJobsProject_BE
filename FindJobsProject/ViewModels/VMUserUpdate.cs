using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels
{
    public class VMUserUpdate
    {
        public Guid id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public bool approve { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
