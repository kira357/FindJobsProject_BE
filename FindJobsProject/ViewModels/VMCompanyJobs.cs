using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels
{
    public class VMCompanyJobs
    {
        public Guid idCompany;
        public Guid idJobs;
        public string imageSrc;
        public string type; 
        public string name;
        public string dayLeft;
        public string dateWork; 
        public bool active; 
        public string Tag; 
    }
}
