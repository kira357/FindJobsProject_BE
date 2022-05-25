using System;

namespace FindJobsProject.ViewModels.VMBlog
{
    public class VMGetBlog
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public long? IdMajor { get; set; }
        public string? NameMajor { get; set; }
        public string Description { get; set; }

        public DateTime DatePost { get; set; }

        public bool IsActive { get; set; }
    }
}
