using System;
using System.Collections.Generic;
using System.Text;

using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindJobsProject.Data.Configurations
{
 public class CommentConfiguration:IEntityTypeConfiguration<Comment>
    {
        public void Configure (EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment")
                    .HasOne<AppUser>(s => s.UserComment)
                    .WithMany(g => g.UserComment)
                    .HasForeignKey(s => s.IdUser)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
