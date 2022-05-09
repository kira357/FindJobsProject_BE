using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels
{
    public class VMUserRegister
    {
       public string Email { get; set; }
       public string UserName { get; set; }
       public string Password { get; set; }
       public string Name { get; set; }
        public string Position { get; set; }
       public bool Approve { get; set; }
       public Guid IdEmployee { get; set; }
       
        public string Address { get; set; }

        public VMUserRegister()
        {

        }

    }
}
