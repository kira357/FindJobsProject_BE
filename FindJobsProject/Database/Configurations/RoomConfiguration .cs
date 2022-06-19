using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;

namespace FindJobsProject.Data.Configurations
{
   public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure (EntityTypeBuilder<Room> builder)
        {
            //builder.ToTable("Room");
            //builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            //builder.HasOne(x => x.UserCreate)
            //    .WithMany(x => x.Rooms)
            //    .IsRequired();
            
        }
    }
}
