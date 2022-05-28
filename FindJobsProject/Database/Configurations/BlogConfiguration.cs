using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;

namespace FindJobsProject.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog")
            .HasOne<AppUser>(s => s.UserBlog)
            .WithMany(g => g.UserBlog)
            .HasForeignKey(s => s.IdUser)
            .OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}