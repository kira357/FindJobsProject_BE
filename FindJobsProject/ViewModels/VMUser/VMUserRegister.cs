using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels
{
    public class VMUserRegister
    {
       public string Email { get; set; }
       public string Password { get; set; }
       public string FirstName { get; set; }
       public string FullName { get; set; }
        public string UserName { get; set; }
       public string Description { get; set; }

       public DateTimeOffset? DateOfBirth { get; set; }

        public string LastName { get; set; }
       public string Name { get; set; }
       public string RoleName { get; set; }
        public long IdRole { get; set; }
       public string PhoneNumber { get; set; }
       public string Major { get; set; }
       public string Gender { get; set; }
        public bool? IsActive { get; set; }

        public string Address { get; set; }

        // recruitment register
        public string NameCompany { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        public string logo { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
    }
}
