using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;

namespace FindJobsProject.Data.Configurations
{
   public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure (EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");
            builder.Property(x => x.Msg).IsRequired().HasMaxLength(500);

            //builder.HasOne(x => x.Room)
            //        .WithMany(x => x.Messages)
            //        .HasForeignKey(x => x.IdRooom)
            //        .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.FromUser)
                    .WithMany(x => x.Messages)
                    .HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
