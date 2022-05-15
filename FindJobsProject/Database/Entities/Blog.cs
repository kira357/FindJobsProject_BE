using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Database.Entities
{
    public class Blog
    {
        [Key]
        public Guid IdBlog { get; set; }
        
        public string TItle { get; set; }

        public Guid IdMajor { get; set; }

        public Guid UserId { get; set; }
        public AppUser UserBlog { get; set; }

        public bool IsActive { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
