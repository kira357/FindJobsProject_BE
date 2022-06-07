﻿using FindJobsProject.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.Database.Entities
{
    public class FavoritesBlogs
    {
 
        public Guid idBlog { get; set; }
        public Blog Blogs { get; set; }
        public Guid IdUser { get; set; }
        public AppUser Users { get; set; }
        public bool isLike { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
