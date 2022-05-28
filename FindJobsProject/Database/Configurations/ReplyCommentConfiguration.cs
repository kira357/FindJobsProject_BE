using System;
using System.Collections.Generic;
using System.Text;

using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindJobsProject.Data.Configurations
{
 public class ReplyCommentConfiguration:IEntityTypeConfiguration<ReplyComment>
    {
        public void Configure (EntityTypeBuilder<ReplyComment> builder)
        {
            builder.ToTable("ReplyComment")
                .HasOne<AppUser>(sc => sc.User)
                .WithMany(s => s.UserReplyComment)
                .HasForeignKey(sc => sc.IdUser);

            builder.ToTable("ReplyComment")
                .HasOne<Comment>(sc => sc.Comment)
                .WithMany(s => s.Replies)
                .HasForeignKey(sc => sc.IdComment);
        }

    }
}
