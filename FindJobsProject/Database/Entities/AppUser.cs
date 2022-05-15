using FindJobsProject.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Database.Entities
{
        public class AppUser : IdentityUser<Guid>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
            public DateTimeOffset? DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string Comment { get; set; }
            public string Address { get; set; }

            public long? IdMajor { get; set; }
            public Major UserMajor { get; set; }

        public string UrlAvatar { get; set; }

            public string Description { get; set; }

            public IList<RecruitmentJob> RecruitmentJob { get; set; }
            public IList<CandidateJob> CandidateJob { get; set; }
            public ICollection<Blog> UserBlog { get; set; }

    }
    
}
