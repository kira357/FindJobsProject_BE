using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Models
{
    public class Organization
    {
        [Key]
        public string Username { get; set;  }
        public string Password { get; set;  }

        public Organization()
        {
            Username = "admin";
            Password = "admin";
        }
        public Organization(string username , string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
