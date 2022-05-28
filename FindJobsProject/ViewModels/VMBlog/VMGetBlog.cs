using System;

namespace FindJobsProject.ViewModels.VMBlog
{
    public class VMGetBlog
    {
        public Guid IdBlog { get; set; }
        public Guid IdUser { get; set; }
        public string Title { get; set; }
        public string NameUser { get; set; }
        public string ImageUser { get; set; }

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
    }
}
