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

        public string Title { get; set; }

        public string Image { get; set; }

        public long? IdMajor { get; set; }
        public string? NameMajor { get; set; }
        public string? Summary { get; set; }
        public string Description { get; set; }
        public DateTime DatePost { get; set; }
        public string Status { get; set; }
        public int? View { get; set; }
        public bool IsActive { get; set; }
        public bool HotPost { get; set; }

        public Guid IdUser { get; set; }
        public AppUser UserBlog { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
