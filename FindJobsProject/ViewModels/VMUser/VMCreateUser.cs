using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.ViewModels.VMUser
{
    public class VMCreateUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }

        public string LastName { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set; }
        public long? IdMajor { get; set; }
        public string NameMajor { get; set; }
        public string UrlAvatar { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }
        public string Gender { get; set; }

        public string Address { get; set; }

        public bool? IsActive { get; set; }
    }
}
