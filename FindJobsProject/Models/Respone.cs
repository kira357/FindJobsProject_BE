using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJobsProject.ViewModels;

namespace FindJobsProject.Models
{
    public class Respone
    {
        public string Ok { get; set; }
        public string Mess { get; set; }
        public string Fail { get; set; }
        public bool Active { get; set; }
        public string Token { get; set; }
        public string Expire { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }

        public List<VMCompany> dataCompany { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int count { get; set; }
    }
}
