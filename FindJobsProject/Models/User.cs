using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public bool Approve { get; set; }

        public Guid IdEmployee { get; set; }
        virtual public Employees employees { get; set; }

        virtual public Company company { get; set; }

    }
}
