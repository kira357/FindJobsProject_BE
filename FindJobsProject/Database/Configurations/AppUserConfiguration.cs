using System;
using System.Collections.Generic;
using System.Text;

using FindJobsProject.Data.Entities;
using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindJobsProject.Data.Configurations
{
 public   class AppUserConfiguration:IEntityTypeConfiguration<AppUser>
    {
        public void Configure (EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers")
                    .HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);

            builder.ToTable("AppUsers")
                    .HasOne<Major>(s => s.UserMajor)
                    .WithMany(g => g.UserMajor)
                    .HasForeignKey(s => s.IdMajor);
        }

    }
}
