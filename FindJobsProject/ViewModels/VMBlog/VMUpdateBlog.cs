using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.ViewModels.VMBlog
{
    public class VMUpdateBlog
    {
        public Guid IdBlog { get; set; }
        public Guid IdUser { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }

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
