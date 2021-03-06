using FindJobsProject.Database.Entities;
using System;

namespace FindJobsProject.ViewModels.VMUser
{
    public class VMGetUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int? Experience { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public Guid RoleId { get; set; }
        public long? IdMajor { get; set; }
        public string NameMajor { get; set; }
        public Major UserMajor { get; set; }

        public string UrlAvatar { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }
    }
}
